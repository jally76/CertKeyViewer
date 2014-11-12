namespace CertKeyView
{
    partial class frmCertGenerate
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
            this.chkSaveInCurrentUser = new System.Windows.Forms.CheckBox();
            this.btnGenerateCert = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMakeCertPath = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCertName = new System.Windows.Forms.TextBox();
            this.txtExportData = new System.Windows.Forms.TextBox();
            this.chkEncryptExport = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // chkSaveInCurrentUser
            // 
            this.chkSaveInCurrentUser.AutoSize = true;
            this.chkSaveInCurrentUser.Checked = true;
            this.chkSaveInCurrentUser.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSaveInCurrentUser.Location = new System.Drawing.Point(354, 12);
            this.chkSaveInCurrentUser.Name = "chkSaveInCurrentUser";
            this.chkSaveInCurrentUser.Size = new System.Drawing.Size(132, 16);
            this.chkSaveInCurrentUser.TabIndex = 4;
            this.chkSaveInCurrentUser.Text = "只在当前用户中保存";
            this.chkSaveInCurrentUser.UseVisualStyleBackColor = true;
            // 
            // btnGenerateCert
            // 
            this.btnGenerateCert.Location = new System.Drawing.Point(366, 126);
            this.btnGenerateCert.Name = "btnGenerateCert";
            this.btnGenerateCert.Size = new System.Drawing.Size(129, 35);
            this.btnGenerateCert.TabIndex = 0;
            this.btnGenerateCert.Text = "产生证书";
            this.btnGenerateCert.UseVisualStyleBackColor = true;
            this.btnGenerateCert.Click += new System.EventHandler(this.btnGenerateCert_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "MakeCert.exe文件所在路径";
            // 
            // txtMakeCertPath
            // 
            this.txtMakeCertPath.Location = new System.Drawing.Point(13, 44);
            this.txtMakeCertPath.Name = "txtMakeCertPath";
            this.txtMakeCertPath.Size = new System.Drawing.Size(435, 21);
            this.txtMakeCertPath.TabIndex = 6;
            this.txtMakeCertPath.Text = "C:\\Program Files\\Microsoft SDKs\\Windows\\v7.0A\\bin";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(451, 45);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(35, 20);
            this.button1.TabIndex = 7;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "证书名称";
            // 
            // txtCertName
            // 
            this.txtCertName.Location = new System.Drawing.Point(112, 85);
            this.txtCertName.Name = "txtCertName";
            this.txtCertName.Size = new System.Drawing.Size(276, 21);
            this.txtCertName.TabIndex = 9;
            this.txtCertName.Text = "JunnetTest";
            // 
            // txtExportData
            // 
            this.txtExportData.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtExportData.Location = new System.Drawing.Point(0, 180);
            this.txtExportData.Multiline = true;
            this.txtExportData.Name = "txtExportData";
            this.txtExportData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtExportData.Size = new System.Drawing.Size(663, 413);
            this.txtExportData.TabIndex = 10;
            // 
            // chkEncryptExport
            // 
            this.chkEncryptExport.AutoSize = true;
            this.chkEncryptExport.Checked = true;
            this.chkEncryptExport.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEncryptExport.Location = new System.Drawing.Point(14, 145);
            this.chkEncryptExport.Name = "chkEncryptExport";
            this.chkEncryptExport.Size = new System.Drawing.Size(72, 16);
            this.chkEncryptExport.TabIndex = 11;
            this.chkEncryptExport.Text = "加密导出";
            this.chkEncryptExport.UseVisualStyleBackColor = true;
            // 
            // frmCertGenerate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 593);
            this.Controls.Add(this.chkEncryptExport);
            this.Controls.Add(this.txtExportData);
            this.Controls.Add(this.txtCertName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtMakeCertPath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkSaveInCurrentUser);
            this.Controls.Add(this.btnGenerateCert);
            this.Name = "frmCertGenerate";
            this.Text = "证书密钥查看器";
            this.Load += new System.EventHandler(this.frmCertGenerate_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkSaveInCurrentUser;
        private System.Windows.Forms.Button btnGenerateCert;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMakeCertPath;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCertName;
        private System.Windows.Forms.TextBox txtExportData;
        private System.Windows.Forms.CheckBox chkEncryptExport;
    }
}

