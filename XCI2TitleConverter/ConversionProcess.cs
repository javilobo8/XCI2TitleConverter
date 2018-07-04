using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace XCI2TitleConverter
{
    class ConversionProcess
    {
        private static string TEMP_DIR = Path.Combine(".", "temp");
        private ConversionConfig config;
        private HactoolWrapper hactool;

        private string targetTitleId;
        private string titlePath;
        private string securePath;
        private string xciFileAbsolutePath;
        private string romfsPath;
        private string exefsPath;

        private string largestNCAFileAbsolutePath;
        private string originalTitleId;

        public ConversionProcess(ConversionConfig config)
        {
            this.config = config;

            targetTitleId = this.config.targetTitleId.ToUpper();

            titlePath = Path.Combine(this.config.outputPath, targetTitleId);
            xciFileAbsolutePath = Path.Combine(this.config.xciPath, this.config.xciFilePath);
            securePath = Path.Combine(TEMP_DIR, "secure");
            romfsPath = Path.Combine(titlePath, "romfs.bin");
            exefsPath = Path.Combine(titlePath, "exefs");

            hactool = new HactoolWrapper(config.hactoolPath, config.keysPath);
        }

        public void run()
        {
            createInitialDirectories();
            decryptXCI();
            saveLargestNCAFile();
            decryptNCA();
            patchNpdm();
            writeInfo();
            cleanStuff();
        }

        private void createInitialDirectories()
        {
            if (Directory.Exists(titlePath))
            {
                Directory.Delete(titlePath, true);
            }

            if (Directory.Exists(TEMP_DIR))
            {
                Directory.Delete(TEMP_DIR, true);
            }

            Directory.CreateDirectory(titlePath);
            Directory.CreateDirectory(TEMP_DIR);

            Directory.CreateDirectory(securePath);
        }

        // TODO: Kill process if MainWindow is closed/killed
        private void decryptXCI()
        {
            Process process = hactool.decryptXCI(securePath, xciFileAbsolutePath);
            
            process.Start();
            process.WaitForExit();
        }

        // TODO: Kill process if MainWindow is closed/killed
        private void decryptNCA()
        {
            Process process = hactool.decryptNCA(romfsPath, exefsPath, largestNCAFileAbsolutePath);
            process.Start();

            var titleIdRegex = new Regex(@"^Title\sID:\s+([a-f0-9]{16})$");

            while (!process.StandardOutput.EndOfStream)
            {
                string line = process.StandardOutput.ReadLine();
                
                if (titleIdRegex.Match(line).Success)
                    originalTitleId = titleIdRegex.Match(line).Groups[1].Value.ToUpper();

                Console.WriteLine(line);
            }
        }

        private void saveLargestNCAFile()
        {
            FileInfo largestFile = new DirectoryInfo(securePath).EnumerateFiles().OrderByDescending(file => file.Length).FirstOrDefault();
            largestNCAFileAbsolutePath = largestFile.FullName;
        }

        private void patchNpdm()
        {
            string npdmFilePath = Path.Combine(exefsPath, "main.npdm");

            // Get little endian base16 hex values
            byte[] titleBytes = new byte[8];
            MatchCollection mc = Regex.Matches(targetTitleId, @"[a-fA-F0-9]{2}");
            for (int i = 0; i < 8; i++)
                titleBytes[i] = Convert.ToByte(mc[i].Value, 16);

            titleBytes = titleBytes.Reverse().ToArray();
            byte[] npdmBytes = File.ReadAllBytes(npdmFilePath);
            File.WriteAllBytes(npdmFilePath + Constants.BACKUP_SUFFIX, npdmBytes);

            byte[] patchedNpdmBytes = Utils.patchTitleId(npdmBytes, titleBytes);

            File.WriteAllBytes(npdmFilePath, npdmBytes);
        }

        public void writeInfo()
        {
            BBBRelease foundItem = config.BBBReleases
                .Find((release) => release.titleid.Equals(originalTitleId));
            if (foundItem != null)
            {
                IniFile iniInfo = new IniFile(Path.Combine(titlePath, "info.ini"));
                iniInfo.Write("titleId", foundItem.titleid, "BACKUP");
                iniInfo.Write("name", foundItem.name, "BACKUP");

                iniInfo.Write("titleId", targetTitleId, "TARGET");

                if (Constants.TARGET_TITLES.TryGetValue(targetTitleId, out string value))
                {
                    if (value != null)
                    {
                        iniInfo.Write("name", value, "TARGET");
                    }
                }
            }
        }

        public void cleanStuff()
        {
            Directory.Delete(TEMP_DIR, true);
        }
    }

    class ConversionConfig
    {
        // Global config
        public string xciPath;
        public string outputPath;
        public string hactoolPath;
        public string keysPath;
        public List<BBBRelease> BBBReleases;

        // Process config
        public string targetTitleId;
        public string xciFilePath;
    }
}
