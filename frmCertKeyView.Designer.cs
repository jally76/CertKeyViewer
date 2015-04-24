namespace CertKeyView
{
    partial class frmCertKeyView
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.chkEncryptExport = new System.Windows.Forms.CheckBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnGenerateCert = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pnlUpper = new System.Windows.Forms.Panel();
            this.txtPublicKey = new System.Windows.Forms.TextBox();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.chkPubShowString = new System.Windows.Forms.CheckBox();
            this.cboCertList = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPrivateKey = new System.Windows.Forms.TextBox();
            this.pnlTop2 = new System.Windows.Forms.Panel();
            this.cboExportFormatType = new System.Windows.Forms.ComboBox();
            this.chkContainsPrivate = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlButtons.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.pnlUpper.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlTop2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.chkEncryptExport);
            this.pnlButtons.Controls.Add(this.btnExport);
            this.pnlButtons.Controls.Add(this.btnDelete);
            this.pnlButtons.Controls.Add(this.btnGenerateCert);
            this.pnlButtons.Controls.Add(this.btnLoad);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtons.Location = new System.Drawing.Point(0, 703);
            this.pnlButtons.Margin = new System.Windows.Forms.Padding(4);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(1008, 76);
            this.pnlButtons.TabIndex = 7;
            // 
            // chkEncryptExport
            // 
            this.chkEncryptExport.AutoSize = true;
            this.chkEncryptExport.Checked = true;
            this.chkEncryptExport.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEncryptExport.Location = new System.Drawing.Point(527, 30);
            this.chkEncryptExport.Margin = new System.Windows.Forms.Padding(4);
            this.chkEncryptExport.Name = "chkEncryptExport";
            this.chkEncryptExport.Size = new System.Drawing.Size(89, 19);
            this.chkEncryptExport.TabIndex = 11;
            this.chkEncryptExport.Text = "加密导出";
            this.chkEncryptExport.UseVisualStyleBackColor = true;
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(352, 20);
            this.btnExport.Margin = new System.Windows.Forms.Padding(4);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(141, 41);
            this.btnExport.TabIndex = 10;
            this.btnExport.Text = "导出...";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(181, 19);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(141, 41);
            this.btnDelete.TabIndex = 9;
            this.btnDelete.Text = "删除";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnGenerateCert
            // 
            this.btnGenerateCert.Location = new System.Drawing.Point(749, 18);
            this.btnGenerateCert.Margin = new System.Windows.Forms.Padding(4);
            this.btnGenerateCert.Name = "btnGenerateCert";
            this.btnGenerateCert.Size = new System.Drawing.Size(172, 44);
            this.btnGenerateCert.TabIndex = 7;
            this.btnGenerateCert.Text = "产生新证书...";
            this.btnGenerateCert.UseVisualStyleBackColor = true;
            this.btnGenerateCert.Click += new System.EventHandler(this.btnGenerateCert_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(19, 18);
            this.btnLoad.Margin = new System.Windows.Forms.Padding(4);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(127, 44);
            this.btnLoad.TabIndex = 8;
            this.btnLoad.Text = "重新加载列表";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.pnlUpper);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.txtPrivateKey);
            this.splitContainer1.Panel2.Controls.Add(this.pnlTop2);
            this.splitContainer1.Size = new System.Drawing.Size(1008, 703);
            this.splitContainer1.SplitterDistance = 333;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 9;
            // 
            // pnlUpper
            // 
            this.pnlUpper.Controls.Add(this.txtPublicKey);
            this.pnlUpper.Controls.Add(this.pnlTop);
            this.pnlUpper.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlUpper.Location = new System.Drawing.Point(0, 0);
            this.pnlUpper.Margin = new System.Windows.Forms.Padding(4);
            this.pnlUpper.Name = "pnlUpper";
            this.pnlUpper.Size = new System.Drawing.Size(1008, 333);
            this.pnlUpper.TabIndex = 9;
            // 
            // txtPublicKey
            // 
            this.txtPublicKey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPublicKey.Location = new System.Drawing.Point(0, 84);
            this.txtPublicKey.Margin = new System.Windows.Forms.Padding(4);
            this.txtPublicKey.Multiline = true;
            this.txtPublicKey.Name = "txtPublicKey";
            this.txtPublicKey.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtPublicKey.Size = new System.Drawing.Size(1008, 249);
            this.txtPublicKey.TabIndex = 12;
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.chkPubShowString);
            this.pnlTop.Controls.Add(this.cboCertList);
            this.pnlTop.Controls.Add(this.label2);
            this.pnlTop.Controls.Add(this.label1);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Margin = new System.Windows.Forms.Padding(4);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1008, 84);
            this.pnlTop.TabIndex = 9;
            // 
            // chkPubShowString
            // 
            this.chkPubShowString.AutoSize = true;
            this.chkPubShowString.Location = new System.Drawing.Point(455, 58);
            this.chkPubShowString.Margin = new System.Windows.Forms.Padding(4);
            this.chkPubShowString.Name = "chkPubShowString";
            this.chkPubShowString.Size = new System.Drawing.Size(119, 19);
            this.chkPubShowString.TabIndex = 13;
            this.chkPubShowString.Text = "只显示字符串";
            this.chkPubShowString.UseVisualStyleBackColor = true;
            this.chkPubShowString.Click += new System.EventHandler(this.chkPubShowString_CheckedChanged);
            // 
            // cboCertList
            // 
            this.cboCertList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCertList.FormattingEnabled = true;
            this.cboCertList.Location = new System.Drawing.Point(124, 16);
            this.cboCertList.Margin = new System.Windows.Forms.Padding(4);
            this.cboCertList.Name = "cboCertList";
            this.cboCertList.Size = new System.Drawing.Size(796, 23);
            this.cboCertList.TabIndex = 12;
            this.cboCertList.SelectedValueChanged += new System.EventHandler(this.cboCertList_SelectedValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 59);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 15);
            this.label2.TabIndex = 10;
            this.label2.Text = "公钥：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 15);
            this.label1.TabIndex = 11;
            this.label1.Text = "证书列表：";
            // 
            // txtPrivateKey
            // 
            this.txtPrivateKey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPrivateKey.Location = new System.Drawing.Point(0, 40);
            this.txtPrivateKey.Margin = new System.Windows.Forms.Padding(4);
            this.txtPrivateKey.Multiline = true;
            this.txtPrivateKey.Name = "txtPrivateKey";
            this.txtPrivateKey.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtPrivateKey.Size = new System.Drawing.Size(1008, 325);
            this.txtPrivateKey.TabIndex = 6;
            // 
            // pnlTop2
            // 
            this.pnlTop2.Controls.Add(this.cboExportFormatType);
            this.pnlTop2.Controls.Add(this.chkContainsPrivate);
            this.pnlTop2.Controls.Add(this.label3);
            this.pnlTop2.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop2.Location = new System.Drawing.Point(0, 0);
            this.pnlTop2.Margin = new System.Windows.Forms.Padding(4);
            this.pnlTop2.Name = "pnlTop2";
            this.pnlTop2.Size = new System.Drawing.Size(1008, 40);
            this.pnlTop2.TabIndex = 7;
            // 
            // cboExportFormatType
            // 
            this.cboExportFormatType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboExportFormatType.FormattingEnabled = true;
            this.cboExportFormatType.Items.AddRange(new object[] {
            "XML文件格式",
            "PEM文件格式"});
            this.cboExportFormatType.Location = new System.Drawing.Point(124, 9);
            this.cboExportFormatType.Name = "cboExportFormatType";
            this.cboExportFormatType.Size = new System.Drawing.Size(207, 23);
            this.cboExportFormatType.TabIndex = 10;
            this.cboExportFormatType.SelectedIndexChanged += new System.EventHandler(this.cboExportFormatType_SelectedIndexChanged);
            // 
            // chkContainsPrivate
            // 
            this.chkContainsPrivate.AutoSize = true;
            this.chkContainsPrivate.Checked = true;
            this.chkContainsPrivate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkContainsPrivate.Location = new System.Drawing.Point(543, 12);
            this.chkContainsPrivate.Margin = new System.Windows.Forms.Padding(4);
            this.chkContainsPrivate.Name = "chkContainsPrivate";
            this.chkContainsPrivate.Size = new System.Drawing.Size(89, 19);
            this.chkContainsPrivate.TabIndex = 9;
            this.chkContainsPrivate.Text = "包含私钥";
            this.chkContainsPrivate.UseVisualStyleBackColor = true;
            this.chkContainsPrivate.Click += new System.EventHandler(this.chkContainsPrivate_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 12);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "私钥：";
            // 
            // frmCertKeyView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 779);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.pnlButtons);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmCertKeyView";
            this.Text = "证书密钥查看器";
            this.Load += new System.EventHandler(this.frmCertKeyView_Load);
            this.pnlButtons.ResumeLayout(false);
            this.pnlButtons.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            this.pnlUpper.ResumeLayout(false);
            this.pnlUpper.PerformLayout();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlTop2.ResumeLayout(false);
            this.pnlTop2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.CheckBox chkEncryptExport;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnGenerateCert;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox txtPrivateKey;
        private System.Windows.Forms.Panel pnlTop2;
        private System.Windows.Forms.CheckBox chkContainsPrivate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel pnlUpper;
        private System.Windows.Forms.TextBox txtPublicKey;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.CheckBox chkPubShowString;
        private System.Windows.Forms.ComboBox cboCertList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboExportFormatType;
    }
}

