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
            this.btnLoad = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cboCertList = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPublicKey = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPrivateKey = new System.Windows.Forms.TextBox();
            this.chkContainsPrivate = new System.Windows.Forms.CheckBox();
            this.chkPubShowString = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(30, 432);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(95, 35);
            this.btnLoad.TabIndex = 0;
            this.btnLoad.Text = "重新加载列表";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "证书列表：";
            // 
            // cboCertList
            // 
            this.cboCertList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCertList.FormattingEnabled = true;
            this.cboCertList.Location = new System.Drawing.Point(111, 25);
            this.cboCertList.Name = "cboCertList";
            this.cboCertList.Size = new System.Drawing.Size(394, 20);
            this.cboCertList.TabIndex = 2;
            this.cboCertList.SelectedValueChanged += new System.EventHandler(this.cboCertList_SelectedValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "公钥：";
            // 
            // txtPublicKey
            // 
            this.txtPublicKey.Location = new System.Drawing.Point(30, 97);
            this.txtPublicKey.Multiline = true;
            this.txtPublicKey.Name = "txtPublicKey";
            this.txtPublicKey.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtPublicKey.Size = new System.Drawing.Size(474, 115);
            this.txtPublicKey.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 232);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "私钥：";
            // 
            // txtPrivateKey
            // 
            this.txtPrivateKey.Location = new System.Drawing.Point(30, 254);
            this.txtPrivateKey.Multiline = true;
            this.txtPrivateKey.Name = "txtPrivateKey";
            this.txtPrivateKey.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtPrivateKey.Size = new System.Drawing.Size(475, 165);
            this.txtPrivateKey.TabIndex = 3;
            // 
            // chkContainsPrivate
            // 
            this.chkContainsPrivate.AutoSize = true;
            this.chkContainsPrivate.Checked = true;
            this.chkContainsPrivate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkContainsPrivate.Location = new System.Drawing.Point(359, 232);
            this.chkContainsPrivate.Name = "chkContainsPrivate";
            this.chkContainsPrivate.Size = new System.Drawing.Size(72, 16);
            this.chkContainsPrivate.TabIndex = 4;
            this.chkContainsPrivate.Text = "包含私钥";
            this.chkContainsPrivate.UseVisualStyleBackColor = true;
            this.chkContainsPrivate.CheckedChanged += new System.EventHandler(this.chkContainsPrivate_CheckedChanged);
            // 
            // chkPubShowString
            // 
            this.chkPubShowString.AutoSize = true;
            this.chkPubShowString.Location = new System.Drawing.Point(359, 70);
            this.chkPubShowString.Name = "chkPubShowString";
            this.chkPubShowString.Size = new System.Drawing.Size(96, 16);
            this.chkPubShowString.TabIndex = 4;
            this.chkPubShowString.Text = "只显示字符串";
            this.chkPubShowString.UseVisualStyleBackColor = true;
            this.chkPubShowString.CheckedChanged += new System.EventHandler(this.chkPubShowString_CheckedChanged);
            // 
            // frmCertKeyView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 476);
            this.Controls.Add(this.chkPubShowString);
            this.Controls.Add(this.chkContainsPrivate);
            this.Controls.Add(this.txtPrivateKey);
            this.Controls.Add(this.txtPublicKey);
            this.Controls.Add(this.cboCertList);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLoad);
            this.Name = "frmCertKeyView";
            this.Text = "证书密钥查看器";
            this.Load += new System.EventHandler(this.frmCertKeyView_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboCertList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPublicKey;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPrivateKey;
        private System.Windows.Forms.CheckBox chkContainsPrivate;
        private System.Windows.Forms.CheckBox chkPubShowString;
    }
}

