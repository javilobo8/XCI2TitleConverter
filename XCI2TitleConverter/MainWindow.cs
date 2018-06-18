using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static XCI2TitleConverter.Utils;

namespace XCI2TitleConverter
{
    public partial class MainWindow : Form
    {
        private string[] xciList = new string[] { };
        private string pathXCIDir = "";
        private string pathOutput = "";
        private string pathHactool = "";
        private string pathKeys = "";

        public MainWindow()
        {
            InitializeComponent();
            this.Text = getWindowTitle();
            pathXCIDir = Properties.Settings.Default.pathXCIDir;
            pathOutput = Properties.Settings.Default.pathOutput;
            pathHactool = Properties.Settings.Default.pathHactool;
            pathKeys = Properties.Settings.Default.pathKeys;
            updateFormValues();
            readXCIDirectory();
        }

        private void updateFormValues()
        {
            txtXCIDir.Text = pathXCIDir;
            txtOutput.Text = pathOutput;
            txtHactool.Text = pathHactool;
            txtKeys.Text = pathKeys;
        }

        private void readXCIDirectory()
        {
            if (pathXCIDir == null || pathXCIDir == "") return;

            DirectoryInfo directory = new DirectoryInfo(pathXCIDir);
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

        private void btnXCIDir_Click(object sender, EventArgs e)
        {
            using (var folderBrowserDialog = new FolderBrowserDialog())
            {
                DialogResult result = folderBrowserDialog.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath))
                {
                    pathXCIDir = folderBrowserDialog.SelectedPath;
                    updateFormValues();
                    Properties.Settings.Default["pathXCIDir"] = folderBrowserDialog.SelectedPath;
                    Properties.Settings.Default.Save();
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
                    pathOutput = folderBrowserDialog.SelectedPath;
                    updateFormValues();
                    Properties.Settings.Default["pathOutput"] = folderBrowserDialog.SelectedPath;
                    Properties.Settings.Default.Save();
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
                pathHactool = fileDialog.FileName;
                updateFormValues();
                Properties.Settings.Default["pathHactool"] = fileDialog.FileName;
                Properties.Settings.Default.Save();
            }
        }

        private void btnKeys_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Keyset|*.txt";
            openFileDialog1.Title = "Select a hacktool.exe";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pathKeys = openFileDialog1.FileName;
                updateFormValues();
                Properties.Settings.Default["pathKeys"] = openFileDialog1.FileName;
                Properties.Settings.Default.Save();
            }
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            ActiveControl = label1;
            foreach (KeyValuePair<string, string> title in Constants.TARGET_TITLES)
            {
                ComboboxItem item = new ComboboxItem();
                item.Text = title.Value;
                item.Value = title.Key;
                cmbTarget.Items.Add(item);
            }
        }

        private void cmbTarget_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTitleId.Text = ((ComboboxItem)cmbTarget.SelectedItem).Value.ToString();
        }

        private string getLargestFileInPath(string path)
        {
            return new DirectoryInfo(path)
                .EnumerateFiles()
                .OrderByDescending(f => f.Length)
                .FirstOrDefault()
                .FullName;
        }

        private bool areParamsValid()
        {
            if (pathXCIDir == "")
            {
                MessageBox.Show("Missing XCI path", null, MessageBoxButtons.OK);
                return false;
            }

            if (pathOutput == "")
            {
                MessageBox.Show("Missing output path", null, MessageBoxButtons.OK);
                return false;
            }

            if (pathHactool == "")
            {
                MessageBox.Show("Missing hactool filepath", null, MessageBoxButtons.OK);
                return false;
            }

            if (pathKeys == "")
            {
                MessageBox.Show("Missing keys filepath", null, MessageBoxButtons.OK);
                return false;
            }

            if (txtTitleId.Text == "")
            {
                MessageBox.Show("Missing title id value", null, MessageBoxButtons.OK);
                return false;
            }

            if (!(new Regex(@"^[a-fA-F0-9]{16}$")).Match(txtTitleId.Text).Success)
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
            if (xciFile == "")
            {
                MessageBox.Show("Missing xci file value", null, MessageBoxButtons.OK);
                return false;
            }

            return true;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (!areParamsValid()) return;

            try
            {
                string xciFile = ((ComboboxItem)cmbXCIFile.SelectedItem).Text.ToString();
                new ConversionProcess(new ConversionConfig {
                    xciPath = pathXCIDir,
                    outputPath = pathOutput,
                    hactoolPath = pathHactool,
                    keysPath = pathKeys,
                    targetTitleId = txtTitleId.Text,
                    xciFilePath = ((ComboboxItem)cmbXCIFile.SelectedItem).Text.ToString(),
                }).run();
            }
            catch (Exception excep)
            {
                Console.Write(excep);
                MessageBox.Show(excep.Message + excep.StackTrace, null, MessageBoxButtons.OK);
                return;
            }
        }

        private void lnklblTitleList_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(Constants.TITLE_LIST_URL);
        }
    }
}
