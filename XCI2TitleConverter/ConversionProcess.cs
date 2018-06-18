using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace XCI2TitleConverter
{
    class ConversionProcess
    {
        public static string XCI_DECRYPT_ARGS = "--intype=xci --securedir=\"{0}\" \"{1}\"";
        public static string NCA_DECRYPT_ARGS = "--keyset=\"{0}\" --romfs=\"{1}\" --exefsdir=\"{2}\" \"{3}\"";

        private ConversionConfig config;

        private string targetTitleId;
        private string titlePath;
        private string securePath;
        private string xciFileAbsolutePath;
        private string romfsPath;
        private string exefsPath;

        private string largestNCAFileAbsolutePath;

        private Thread runThread;

        public ConversionProcess(ConversionConfig config)
        {
            this.config = config;

            targetTitleId = this.config.targetTitleId.ToUpper();

            titlePath = Path.Combine(this.config.outputPath, targetTitleId);
            xciFileAbsolutePath = Path.Combine(this.config.xciPath, this.config.xciFilePath);
            securePath = Path.Combine(titlePath, "secure");
            romfsPath = Path.Combine(titlePath, "romfs.bin");
            exefsPath = Path.Combine(titlePath, "exefs");
        }

        public void run()
        {
            Console.WriteLine("Starting conversion");
            runThread = new Thread(process);
            runThread.Start();
        }

        public void process()
        {
            createInitialDirectories();
            decryptXCI();
            saveLargestNCAFile();
            decryptNCA();
            patchNpdm();
            cleanStuff();

            // Changeme
            MessageBox.Show("Success!", "Message", MessageBoxButtons.OK);
        }

        private void createInitialDirectories()
        {
            Console.Write("Creating initial directories...");
            // TODO: msgbox?
            if (Directory.Exists(titlePath))
            {
                Directory.Delete(titlePath, true);
            }

            Directory.CreateDirectory(titlePath);

            Directory.CreateDirectory(securePath);
            Console.WriteLine("done");
        }

        // TODO: Kill process if MainWindow is closed/killed
        private void decryptXCI()
        {
            Process process = new Process {
                StartInfo = new ProcessStartInfo {
                    FileName = config.hactoolPath,
                    Arguments = String.Format(XCI_DECRYPT_ARGS, securePath, xciFileAbsolutePath),
                    UseShellExecute = false,
                    RedirectStandardOutput = false,
                    CreateNoWindow = false,
                }
            };

            Console.Write("Decrypting XCI...");
            process.Start();
            process.WaitForExit();
            Console.WriteLine("done");
        }

        // TODO: Kill process if MainWindow is closed/killed
        private void decryptNCA()
        {
            Process process = new Process {
                StartInfo = new ProcessStartInfo {
                    FileName = config.hactoolPath,
                    Arguments = String.Format(NCA_DECRYPT_ARGS, config.keysPath, romfsPath, exefsPath, largestNCAFileAbsolutePath),
                    UseShellExecute = false,
                    RedirectStandardOutput = false,
                    CreateNoWindow = false,
                }
            };

            Console.Write("Decrypting NCA...");
            process.Start();
            process.WaitForExit();
            Console.WriteLine("done");
        }

        private void saveLargestNCAFile()
        {
            Console.Write("Saving largest NCA file...");
            this.largestNCAFileAbsolutePath = new DirectoryInfo(securePath)
                .EnumerateFiles()
                .OrderByDescending(file => file.Length)
                .FirstOrDefault()
                .FullName;
            Console.WriteLine("done");
        }

        // Thanks to Falo@GBATemp
        private void patchNpdm()
        {
            Console.Write("Patching main.npdm file...");
            ulong targetTitleIdULong = Convert.ToUInt64(targetTitleId, 16);
            string npdmFilePath = Path.Combine(exefsPath, "main.npdm");
            byte[] npdmBytes = File.ReadAllBytes(npdmFilePath);

            int aci0RawOffset = BitConverter.ToInt32(npdmBytes, 0x70);

            if (npdmBytes[aci0RawOffset] != 0x41 ||
                npdmBytes[aci0RawOffset + 1] != 0x43 ||
                npdmBytes[aci0RawOffset + 2] != 0x49 ||
                npdmBytes[aci0RawOffset + 3] != 0x30)
            {
                throw new Exception("Unable to decrypt NCA file, check your keyset! You should remove created files.");
            }

            byte[] patchedNpdmBytes = BitConverter.GetBytes(targetTitleIdULong);

            Array.Copy(patchedNpdmBytes, 0, npdmBytes, aci0RawOffset + 0x10, patchedNpdmBytes.Length);

            File.WriteAllBytes(npdmFilePath, patchedNpdmBytes);
            Console.WriteLine("done");
        }

        public void cleanStuff()
        {
            Console.Write("Cleaning stuff...");
            // Remove secure path with nca files
            Directory.Delete(securePath, true);

            // Create title info
            Console.WriteLine("done");
        }
    }

    public struct ConversionConfig
    {
        // Global config
        public string xciPath;
        public string outputPath;
        public string hactoolPath;
        public string keysPath;

        // Process config
        public string targetTitleId;
        public string xciFilePath;
    }
}
