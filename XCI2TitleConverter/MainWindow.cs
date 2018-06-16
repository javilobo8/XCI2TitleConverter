using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace XCI2TitleConverter
{
    public partial class MainWindow : Form
    {
        private string[] xciList = new string[] { };
        private string pathXCIDir = "";
        private string pathOutput = "";
        private string pathHactool = "";
        private string pathKeys = "";
        private string targetTitleId = "";

        public MainWindow()
        {
            InitializeComponent();
            this.pathXCIDir = Properties.Settings.Default.pathXCIDir;
            this.pathOutput = Properties.Settings.Default.pathOutput;
            this.pathHactool = Properties.Settings.Default.pathHactool;
            this.pathKeys = Properties.Settings.Default.pathKeys;
            this.updateFormValues();
            this.readXCIDirectory();
        }

        private void updateFormValues()
        {
            this.txtXCIDir.Text = this.pathXCIDir;
            this.txtOutput.Text = this.pathOutput;
            this.txtHactool.Text = this.pathHactool;
            this.txtKeys.Text = this.pathKeys;
            this.txtTitleId.Text = this.targetTitleId;
        }

        private void readXCIDirectory()
        {
            if (this.pathXCIDir == null || this.pathXCIDir == "")
            {
                return;
            }

            DirectoryInfo d = new DirectoryInfo(this.pathXCIDir);
            FileInfo[] Files = d.GetFiles("*.xci");

            this.cmbXCIFile.Items.Clear();
            this.cmbXCIFile.SelectedItem = -1;
            this.cmbXCIFile.Text = "";
            foreach (FileInfo file in Files)
            {
                ComboboxItem item = new ComboboxItem();
                item.Text = file.Name;
                this.cmbXCIFile.Items.Add(item);
            }
        }

        private void btnXCIDir_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    this.pathXCIDir = fbd.SelectedPath;
                    this.updateFormValues();
                    Properties.Settings.Default["pathXCIDir"] = fbd.SelectedPath;
                    Properties.Settings.Default.Save();
                    this.readXCIDirectory();
                }
            }
        }

        private void btnOutput_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    this.pathOutput = fbd.SelectedPath;
                    this.updateFormValues();
                    Properties.Settings.Default["pathOutput"] = fbd.SelectedPath;
                    Properties.Settings.Default.Save();
                }
            }
        }

        private void btnHactool_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Hactool binary|hactool.exe";
            openFileDialog1.Title = "Select a hacktool.exe";
         
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.pathHactool = openFileDialog1.FileName;
                this.updateFormValues();
                Properties.Settings.Default["pathHactool"] = openFileDialog1.FileName;
                Properties.Settings.Default.Save();
            }
        }

        private void btnKeys_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Keyset|*.txt";
            openFileDialog1.Title = "Select a hacktool.exe";

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.pathKeys = openFileDialog1.FileName;
                this.updateFormValues();
                Properties.Settings.Default["pathKeys"] = openFileDialog1.FileName;
                Properties.Settings.Default.Save();
            }
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            this.ActiveControl = label1;
            foreach (KeyValuePair<string, string> title in Constants.TARGET_TITLES)
            {
                ComboboxItem item = new ComboboxItem();
                item.Text = title.Value;
                item.Value = title.Key;
                this.cmbTarget.Items.Add(item);
            }
        }

        private void cmbTarget_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.targetTitleId = ((ComboboxItem)cmbTarget.SelectedItem).Value.ToString();
            this.updateFormValues();
        }

        private string getLargestFileInPath(string path)
        {
            FileInfo largestFile = new DirectoryInfo(path).EnumerateFiles().OrderByDescending(f => f.Length).FirstOrDefault();

            return largestFile.FullName;
        }

        private bool isParamsValid()
        {
            if (this.pathXCIDir == null || this.pathXCIDir == "")
            {
                MessageBox.Show("Missing XCI path", null, MessageBoxButtons.OK);
                return false;
            }

            if (this.pathOutput == null || this.pathOutput == "")
            {
                MessageBox.Show("Missing output path", null, MessageBoxButtons.OK);
                return false;
            }

            if (this.pathHactool == null || this.pathHactool == "")
            {
                MessageBox.Show("Missing hactool filepath", null, MessageBoxButtons.OK);
                return false;
            }

            if (this.pathKeys == null || this.pathKeys == "")
            {
                MessageBox.Show("Missing keys filepath", null, MessageBoxButtons.OK);
                return false;
            }

            if (this.txtTitleId.Text == null || this.txtTitleId.Text == "")
            {
                MessageBox.Show("Missing title id value", null, MessageBoxButtons.OK);
                return false;
            }

            if (!(new Regex(@"^[a-fA-F0-9]{16}$")).Match(this.txtTitleId.Text).Success)
            {
                MessageBox.Show("Wrong title id format", null, MessageBoxButtons.OK);
                return false;
            }

            
            if ((ComboboxItem)cmbXCIFile.SelectedItem == null)
            {
                MessageBox.Show("Missing xci file value", null, MessageBoxButtons.OK);
                return false;
            }

            string xciFile = ((ComboboxItem)cmbXCIFile.SelectedItem).Text.ToString();
            if (xciFile == null || xciFile == "")
            {
                MessageBox.Show("Missing xci file value", null, MessageBoxButtons.OK);
                return false;
            }

            return true;
        }

        // Thanks to Falo@GBATemp
        private bool patchNPDM(string filePath, string targetTitleIdString)
        {
            ulong targetTitleId = (ulong)Convert.ToInt64(targetTitleIdString, 16);

            byte[] data = File.ReadAllBytes(filePath);
            File.WriteAllBytes(filePath + ".backup", data);

            int aci0RawOffset = BitConverter.ToInt32(data, 0x70);

            if (data[aci0RawOffset] != 0x41 || data[aci0RawOffset + 1] != 0x43 || data[aci0RawOffset + 2] != 0x49 || data[aci0RawOffset + 3] != 0x30)
            {
                return false;
            }

            byte[] TitleIdBytes = BitConverter.GetBytes(targetTitleId);

            Array.Copy(TitleIdBytes, 0, data, aci0RawOffset + 0x10, TitleIdBytes.Length);

            File.Delete(filePath);
            File.WriteAllBytes(filePath, data);
            return true;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            // Validate form values
            if (!this.isParamsValid()) return;

            string targetTitleId = this.txtTitleId.Text.ToUpper();

            string xciFile = ((ComboboxItem)cmbXCIFile.SelectedItem).Text.ToString();
            string tilePath = Path.Combine(this.pathOutput, targetTitleId);
            string securePath = Path.Combine(tilePath, "secure");
            string xciFilePath = Path.Combine(this.pathXCIDir, xciFile);
            string romfsFile = Path.Combine(tilePath, "romfs.bin");
            string exefsPath = Path.Combine(tilePath, "exefs");

            if (Directory.Exists(tilePath))
            {
                Directory.Delete(tilePath, true);
            }

            Directory.CreateDirectory(tilePath);
            DirectoryInfo secureDirectory = Directory.CreateDirectory(securePath);

            // Decrypt XCI
            string decryptXCIargs = String.Format("--intype=xci --securedir=\"{0}\" \"{1}\"", securePath, xciFilePath);
            var decryptXCIProcess = Process.Start(this.pathHactool, decryptXCIargs);
            decryptXCIProcess.WaitForExit();

            // Decrypt NCA
            string largestNCAFile = this.getLargestFileInPath(securePath);
            string decryptNCAargs = String.Format("--keyset=\"{0}\" --romfs=\"{1}\" --exefsdir=\"{2}\" \"{3}\"", this.pathKeys, romfsFile, exefsPath, largestNCAFile);
            var decryptNCAProcess = Process.Start(this.pathHactool, decryptNCAargs);
            decryptNCAProcess.WaitForExit();

            secureDirectory.Delete(true);
            
            // Save empty file with decrypted XCI name
            File.Create(Path.Combine(tilePath, "ORIGINAL_" + xciFile));

            if (!Directory.Exists(exefsPath))
            {
                MessageBox.Show("Unable to decrypt NCA file, check your keyset! You should remove created files.", null, MessageBoxButtons.OK);
                return;
            }

            if (!this.patchNPDM(Path.Combine(exefsPath, "main.npdm"), targetTitleId))
            {
                MessageBox.Show("ACI0 magic bytes not found. did you select the right file (main.npdm)?", null, MessageBoxButtons.OK);
                return;
            }

            MessageBox.Show("Success!", this.Text, MessageBoxButtons.OK);
            return;
        }

        private void lnklblTitleList_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://switchbrew.org/index.php?title=Title_list/Games");
        }
    }
    public class ComboboxItem
    {
        public string Text { get; set; }
        public object Value { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }
}
