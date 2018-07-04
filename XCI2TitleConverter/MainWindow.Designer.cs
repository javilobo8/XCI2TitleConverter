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
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbTarget = new System.Windows.Forms.ComboBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnOutput = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.txtTitleId = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.lnklblTitleList = new System.Windows.Forms.LinkLabel();
            this.listViewXCI = new System.Windows.Forms.ListView();
            this.fileSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.fileName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // txtXCIDir
            // 
            this.txtXCIDir.Location = new System.Drawing.Point(296, 26);
            this.txtXCIDir.Name = "txtXCIDir";
            this.txtXCIDir.ReadOnly = true;
            this.txtXCIDir.Size = new System.Drawing.Size(244, 20);
            this.txtXCIDir.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(293, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "XCI directory path";
            // 
            // btnXCIDir
            // 
            this.btnXCIDir.Location = new System.Drawing.Point(546, 25);
            this.btnXCIDir.Name = "btnXCIDir";
            this.btnXCIDir.Size = new System.Drawing.Size(63, 22);
            this.btnXCIDir.TabIndex = 2;
            this.btnXCIDir.Text = "Select";
            this.btnXCIDir.UseVisualStyleBackColor = true;
            this.btnXCIDir.Click += new System.EventHandler(this.btnXCIDir_Click);
            // 
            // btnHactool
            // 
            this.btnHactool.Location = new System.Drawing.Point(546, 103);
            this.btnHactool.Name = "btnHactool";
            this.btnHactool.Size = new System.Drawing.Size(63, 22);
            this.btnHactool.TabIndex = 5;
            this.btnHactool.Text = "Select";
            this.btnHactool.UseVisualStyleBackColor = true;
            this.btnHactool.Click += new System.EventHandler(this.btnHactool_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(293, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "hactool.exe path";
            // 
            // txtHactool
            // 
            this.txtHactool.Location = new System.Drawing.Point(296, 104);
            this.txtHactool.Name = "txtHactool";
            this.txtHactool.ReadOnly = true;
            this.txtHactool.Size = new System.Drawing.Size(244, 20);
            this.txtHactool.TabIndex = 3;
            // 
            // btnKeys
            // 
            this.btnKeys.Location = new System.Drawing.Point(546, 142);
            this.btnKeys.Name = "btnKeys";
            this.btnKeys.Size = new System.Drawing.Size(63, 22);
            this.btnKeys.TabIndex = 8;
            this.btnKeys.Text = "Select";
            this.btnKeys.UseVisualStyleBackColor = true;
            this.btnKeys.Click += new System.EventHandler(this.btnKeys_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(293, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "keys.txt path";
            // 
            // txtKeys
            // 
            this.txtKeys.Location = new System.Drawing.Point(296, 143);
            this.txtKeys.Name = "txtKeys";
            this.txtKeys.ReadOnly = true;
            this.txtKeys.Size = new System.Drawing.Size(244, 20);
            this.txtKeys.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Target title to be replaced";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(293, 181);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(128, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Target title to be replaced";
            // 
            // cmbTarget
            // 
            this.cmbTarget.FormattingEnabled = true;
            this.cmbTarget.Location = new System.Drawing.Point(296, 197);
            this.cmbTarget.Name = "cmbTarget";
            this.cmbTarget.Size = new System.Drawing.Size(203, 21);
            this.cmbTarget.TabIndex = 11;
            this.cmbTarget.SelectedIndexChanged += new System.EventHandler(this.cmbTarget_SelectedIndexChanged);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(296, 224);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(313, 29);
            this.btnStart.TabIndex = 13;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnOutput
            // 
            this.btnOutput.Location = new System.Drawing.Point(546, 64);
            this.btnOutput.Name = "btnOutput";
            this.btnOutput.Size = new System.Drawing.Size(63, 22);
            this.btnOutput.TabIndex = 16;
            this.btnOutput.Text = "Select";
            this.btnOutput.UseVisualStyleBackColor = true;
            this.btnOutput.Click += new System.EventHandler(this.btnOutput_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(293, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Output directory path";
            // 
            // txtOutput
            // 
            this.txtOutput.Location = new System.Drawing.Point(296, 65);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ReadOnly = true;
            this.txtOutput.Size = new System.Drawing.Size(244, 20);
            this.txtOutput.TabIndex = 14;
            // 
            // txtTitleId
            // 
            this.txtTitleId.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTitleId.Location = new System.Drawing.Point(505, 197);
            this.txtTitleId.Name = "txtTitleId";
            this.txtTitleId.Size = new System.Drawing.Size(104, 20);
            this.txtTitleId.TabIndex = 17;
            this.txtTitleId.TextChanged += new System.EventHandler(this.txtTitleId_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(502, 181);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "Title ID";
            // 
            // lnklblTitleList
            // 
            this.lnklblTitleList.AutoSize = true;
            this.lnklblTitleList.Location = new System.Drawing.Point(567, 181);
            this.lnklblTitleList.Name = "lnklblTitleList";
            this.lnklblTitleList.Size = new System.Drawing.Size(42, 13);
            this.lnklblTitleList.TabIndex = 22;
            this.lnklblTitleList.TabStop = true;
            this.lnklblTitleList.Text = "Title list";
            this.lnklblTitleList.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnklblTitleList_LinkClicked);
            // 
            // listViewXCI
            // 
            this.listViewXCI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listViewXCI.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.fileSize,
            this.fileName});
            this.listViewXCI.FullRowSelect = true;
            this.listViewXCI.Location = new System.Drawing.Point(12, 24);
            this.listViewXCI.MultiSelect = false;
            this.listViewXCI.Name = "listViewXCI";
            this.listViewXCI.Size = new System.Drawing.Size(275, 229);
            this.listViewXCI.TabIndex = 23;
            this.listViewXCI.UseCompatibleStateImageBehavior = false;
            this.listViewXCI.View = System.Windows.Forms.View.Details;
            this.listViewXCI.SelectedIndexChanged += new System.EventHandler(this.listViewXCI_SelectedIndexChanged);
            // 
            // fileSize
            // 
            this.fileSize.Text = "Size";
            this.fileSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // fileName
            // 
            this.fileName.Text = "Name";
            this.fileName.Width = 198;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 265);
            this.Controls.Add(this.listViewXCI);
            this.Controls.Add(this.lnklblTitleList);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtTitleId);
            this.Controls.Add(this.btnOutput);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbTarget);
            this.Controls.Add(this.label4);
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
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbTarget;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnOutput;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.TextBox txtTitleId;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.LinkLabel lnklblTitleList;
        private System.Windows.Forms.ListView listViewXCI;
        private System.Windows.Forms.ColumnHeader fileSize;
        private System.Windows.Forms.ColumnHeader fileName;
    }
}

