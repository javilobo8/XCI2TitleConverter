using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using XCI2TitleConverter.Properties;
using static XCI2TitleConverter.Utils;

namespace XCI2TitleConverter
{
    public partial class MainWindow : Form
    {
        private string[] xciList = new string[] { };
        private string xciDirPath = "";
        private string outputPath = "";
        private string hactoolPath = "";
        private string keysPath = "";

        private string targetTitleId = "";
        private string selectedXciFilePath = "";

        private List<BBBRelease> BBBReleases = new List<BBBRelease>();

        public MainWindow()
        {
            InitializeComponent();
            this.Text = getWindowTitle();
            xciDirPath = Settings.Default.pathXCIDir;
            outputPath = Settings.Default.pathOutput;
            hactoolPath = Settings.Default.pathHactool;
            keysPath = Settings.Default.pathKeys;
            retriveBBBReleases();
            updateFormValues();
            readXCIDirectory();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            AllocConsole();
            ActiveControl = label1;
            foreach (KeyValuePair<string, string> title in Constants.TARGET_TITLES)
            {
                ComboboxItem item = new ComboboxItem();
                item.Text = title.Value;
                item.Value = title.Key;
                cmbTarget.Items.Add(item);
            }
        }

        private void txtTitleId_TextChanged(object sender, EventArgs e)
        {
            targetTitleId = ((TextBox)sender).Text;
        }

        private void cmbXCIFile_TextChanged(object sender, EventArgs e)
        {
            selectedXciFilePath = ((ComboBox)sender).Text;
        }

        private void btnXCIDir_Click(object sender, EventArgs e)
        {
            using (var folderBrowserDialog = new FolderBrowserDialog())
            {
                DialogResult result = folderBrowserDialog.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath))
                {
                    xciDirPath = folderBrowserDialog.SelectedPath;
                    updateFormValues();
                    Settings.Default["pathXCIDir"] = folderBrowserDialog.SelectedPath;
                    Settings.Default.Save();
                    readXCIDirectory();
                }
            }
        }

        private void btnOutput_Click(object sender, EventArgs e)
        {
            using (var folderBrowserDialog = new FolderBrowserDialog())
            {
                DialogResult result = folderBrowserDialog.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath))
                {
                    outputPath = folderBrowserDialog.SelectedPath;
                    updateFormValues();
                    Settings.Default["pathOutput"] = folderBrowserDialog.SelectedPath;
                    Settings.Default.Save();
                }
            }
        }

        private void btnHactool_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Hactool binary|hactool.exe";
            fileDialog.Title = "Select a hacktool.exe";
         
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                hactoolPath = fileDialog.FileName;
                updateFormValues();
                Settings.Default["pathHactool"] = fileDialog.FileName;
                Settings.Default.Save();
            }
        }

        private void btnKeys_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Keyset|*.txt";
            openFileDialog1.Title = "Select a hacktool.exe";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                keysPath = openFileDialog1.FileName;
                updateFormValues();
                Settings.Default["pathKeys"] = openFileDialog1.FileName;
                Settings.Default.Save();
            }
        }

        private void cmbTarget_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTitleId.Text = ((ComboboxItem)cmbTarget.SelectedItem).Value.ToString();
        }

        private void updateFormValues()
        {
            txtXCIDir.Text = xciDirPath;
            txtOutput.Text = outputPath;
            txtHactool.Text = hactoolPath;
            txtKeys.Text = keysPath;
        }

        private void readXCIDirectory()
        {
            if (xciDirPath == null || xciDirPath == "") return;

            DirectoryInfo directory = new DirectoryInfo(xciDirPath);
            FileInfo[] Files = directory.GetFiles("*.xci");

            cmbXCIFile.Items.Clear();
            cmbXCIFile.SelectedItem = -1;
            cmbXCIFile.Text = "";

            foreach (FileInfo file in Files)
            {
                ComboboxItem item = new ComboboxItem();
                item.Text = file.Name;
                cmbXCIFile.Items.Add(item);
            }
        }

        private void setFormStatus(bool enabled = true) {
            Invoke((MethodInvoker) delegate ()
            {
                btnStart.Text = enabled ? "Start conversion" : "Converting (this might take a while, look at the console)";
                this.Enabled = enabled;
            });
        }

        private void checkParams()
        {
            if (xciDirPath == "")
                throw new Exception("Missing XCI path");
            if (outputPath == "")
                throw new Exception("Missing output path");
            if (hactoolPath == "")
                throw new Exception("Missing hactool filepath");
            if (keysPath == "")
                throw new Exception("Missing keys filepath");
            if (targetTitleId == "")
                throw new Exception("Missing title id value");
            if (!(new Regex(@"^[a-fA-F0-9]{16}$")).Match(targetTitleId).Success)
                throw new Exception("Wrong title id format");
            if (selectedXciFilePath == null)
                throw new Exception("Missing xci file value");
            if (selectedXciFilePath == "")
                throw new Exception("Missing xci file value");
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(() => {
                try
                {
                    checkParams();
                } catch (Exception checkException)
                {
                    MessageBox.Show(checkException.Message, null, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    setFormStatus(false);
                    new ConversionProcess(new ConversionConfig
                    {
                        xciPath = xciDirPath,
                        outputPath = outputPath,
                        hactoolPath = hactoolPath,
                        keysPath = keysPath,
                        targetTitleId = targetTitleId,
                        xciFilePath = selectedXciFilePath,
                        BBBReleases = BBBReleases
                    }).run();
                    MessageBox.Show("Success!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    setFormStatus();
                }
                catch (Exception conversionException)
                {
                    Console.Write(conversionException);
                    MessageBox.Show(conversionException.Message + conversionException.StackTrace, null, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            });

            thread.Start();
        }

        private void lnklblTitleList_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(Constants.TITLE_LIST_URL);
        }

        private void retriveBBBReleases()
        {
            new Thread(() =>
            {
                this.BBBReleases = getBBBReleases();
            }).Start();
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();
    }
}
