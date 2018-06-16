namespace XCI2TitleConverter
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtXCIDir = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnXCIDir = new System.Windows.Forms.Button();
            this.btnHactool = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtHactool = new System.Windows.Forms.TextBox();
            this.btnKeys = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtKeys = new System.Windows.Forms.TextBox();
            this.cmbXCIFile = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbTarget = new System.Windows.Forms.ComboBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnOutput = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.txtTitleId = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lnklblCarltus = new System.Windows.Forms.LinkLabel();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lnklblTitleList = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // txtXCIDir
            // 
            this.txtXCIDir.Location = new System.Drawing.Point(15, 25);
            this.txtXCIDir.Name = "txtXCIDir";
            this.txtXCIDir.ReadOnly = true;
            this.txtXCIDir.Size = new System.Drawing.Size(304, 20);
            this.txtXCIDir.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "XCI directory path";
            // 
            // btnXCIDir
            // 
            this.btnXCIDir.Location = new System.Drawing.Point(325, 24);
            this.btnXCIDir.Name = "btnXCIDir";
            this.btnXCIDir.Size = new System.Drawing.Size(67, 22);
            this.btnXCIDir.TabIndex = 2;
            this.btnXCIDir.Text = "Select";
            this.btnXCIDir.UseVisualStyleBackColor = true;
            this.btnXCIDir.Click += new System.EventHandler(this.btnXCIDir_Click);
            // 
            // btnHactool
            // 
            this.btnHactool.Location = new System.Drawing.Point(325, 102);
            this.btnHactool.Name = "btnHactool";
            this.btnHactool.Size = new System.Drawing.Size(67, 22);
            this.btnHactool.TabIndex = 5;
            this.btnHactool.Text = "Select";
            this.btnHactool.UseVisualStyleBackColor = true;
            this.btnHactool.Click += new System.EventHandler(this.btnHactool_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "hactool.exe path";
            // 
            // txtHactool
            // 
            this.txtHactool.Location = new System.Drawing.Point(15, 103);
            this.txtHactool.Name = "txtHactool";
            this.txtHactool.ReadOnly = true;
            this.txtHactool.Size = new System.Drawing.Size(304, 20);
            this.txtHactool.TabIndex = 3;
            // 
            // btnKeys
            // 
            this.btnKeys.Location = new System.Drawing.Point(325, 141);
            this.btnKeys.Name = "btnKeys";
            this.btnKeys.Size = new System.Drawing.Size(67, 22);
            this.btnKeys.TabIndex = 8;
            this.btnKeys.Text = "Select";
            this.btnKeys.UseVisualStyleBackColor = true;
            this.btnKeys.Click += new System.EventHandler(this.btnKeys_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "keys.txt path";
            // 
            // txtKeys
            // 
            this.txtKeys.Location = new System.Drawing.Point(15, 142);
            this.txtKeys.Name = "txtKeys";
            this.txtKeys.ReadOnly = true;
            this.txtKeys.Size = new System.Drawing.Size(304, 20);
            this.txtKeys.TabIndex = 6;
            // 
            // cmbXCIFile
            // 
            this.cmbXCIFile.FormattingEnabled = true;
            this.cmbXCIFile.Location = new System.Drawing.Point(15, 236);
            this.cmbXCIFile.Name = "cmbXCIFile";
            this.cmbXCIFile.Size = new System.Drawing.Size(377, 21);
            this.cmbXCIFile.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 220);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Target title to be replaced";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 180);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(128, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Target title to be replaced";
            // 
            // cmbTarget
            // 
            this.cmbTarget.FormattingEnabled = true;
            this.cmbTarget.Location = new System.Drawing.Point(15, 196);
            this.cmbTarget.Name = "cmbTarget";
            this.cmbTarget.Size = new System.Drawing.Size(211, 21);
            this.cmbTarget.TabIndex = 11;
            this.cmbTarget.SelectedIndexChanged += new System.EventHandler(this.cmbTarget_SelectedIndexChanged);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(14, 263);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(379, 26);
            this.btnStart.TabIndex = 13;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnOutput
            // 
            this.btnOutput.Location = new System.Drawing.Point(325, 63);
            this.btnOutput.Name = "btnOutput";
            this.btnOutput.Size = new System.Drawing.Size(67, 22);
            this.btnOutput.TabIndex = 16;
            this.btnOutput.Text = "Select";
            this.btnOutput.UseVisualStyleBackColor = true;
            this.btnOutput.Click += new System.EventHandler(this.btnOutput_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Output directory path";
            // 
            // txtOutput
            // 
            this.txtOutput.Location = new System.Drawing.Point(15, 64);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ReadOnly = true;
            this.txtOutput.Size = new System.Drawing.Size(304, 20);
            this.txtOutput.TabIndex = 14;
            // 
            // txtTitleId
            // 
            this.txtTitleId.Location = new System.Drawing.Point(232, 197);
            this.txtTitleId.Name = "txtTitleId";
            this.txtTitleId.Size = new System.Drawing.Size(160, 20);
            this.txtTitleId.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Enabled = false;
            this.label7.Location = new System.Drawing.Point(333, 292);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "@javilobo8";
            // 
            // lnklblCarltus
            // 
            this.lnklblCarltus.AutoSize = true;
            this.lnklblCarltus.Location = new System.Drawing.Point(124, 292);
            this.lnklblCarltus.Name = "lnklblCarltus";
            this.lnklblCarltus.Size = new System.Drawing.Size(23, 13);
            this.lnklblCarltus.TabIndex = 19;
            this.lnklblCarltus.TabStop = true;
            this.lnklblCarltus.Text = "this";
            this.lnklblCarltus.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnklblCarltus_LinkClicked);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 292);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(114, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "Modify main.npdm with";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(229, 180);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "Title ID";
            // 
            // lnklblTitleList
            // 
            this.lnklblTitleList.AutoSize = true;
            this.lnklblTitleList.Location = new System.Drawing.Point(351, 180);
            this.lnklblTitleList.Name = "lnklblTitleList";
            this.lnklblTitleList.Size = new System.Drawing.Size(42, 13);
            this.lnklblTitleList.TabIndex = 22;
            this.lnklblTitleList.TabStop = true;
            this.lnklblTitleList.Text = "Title list";
            this.lnklblTitleList.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnklblTitleList_LinkClicked);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 314);
            this.Controls.Add(this.lnklblTitleList);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lnklblCarltus);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtTitleId);
            this.Controls.Add(this.btnOutput);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbTarget);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbXCIFile);
            this.Controls.Add(this.btnKeys);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtKeys);
            this.Controls.Add(this.btnHactool);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtHactool);
            this.Controls.Add(this.btnXCIDir);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtXCIDir);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "XCI2TitleConverter";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtXCIDir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnXCIDir;
        private System.Windows.Forms.Button btnHactool;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtHactool;
        private System.Windows.Forms.Button btnKeys;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtKeys;
        private System.Windows.Forms.ComboBox cmbXCIFile;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbTarget;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnOutput;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.TextBox txtTitleId;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.LinkLabel lnklblCarltus;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.LinkLabel lnklblTitleList;
    }
}

