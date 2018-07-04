using System;
using System.Diagnostics;

namespace XCI2TitleConverter
{
    class HactoolWrapper
    {
        public static string XCI_DECRYPT_ARGS = "--intype=xci --securedir=\"{0}\" \"{1}\"";
        public static string NCA_DECRYPT_ARGS = "--keyset=\"{0}\" --romfs=\"{1}\" --exefsdir=\"{2}\" \"{3}\"";

        private string hactoolPath;
        private string keysPath;

        public HactoolWrapper(string hactoolPath, string keysPath)
        {
            this.hactoolPath = hactoolPath;
            this.keysPath = keysPath;
        }

        public Process decryptXCI(string securePath, string xciFileAbsolutePath)
        {
            return new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = hactoolPath,
                    Arguments = String.Format(XCI_DECRYPT_ARGS, securePath, xciFileAbsolutePath),
                    UseShellExecute = false,
                    RedirectStandardOutput = false,
                    CreateNoWindow = false,
                }
            };
        }

        public Process decryptNCA(string romfsPath, string exefsPath, string largestNCAFileAbsolutePath)
        {
            return new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = hactoolPath,
                    Arguments = String.Format(NCA_DECRYPT_ARGS, keysPath, romfsPath, exefsPath, largestNCAFileAbsolutePath),
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true,
                }
            };
        }
    }
}
