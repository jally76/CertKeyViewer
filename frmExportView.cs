using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CertKeyView
{
    public partial class frmExportView : Form
    {
        private string mText = "";
        public string ShowText
        {
            get { return mText; }
            set { mText = value; }
        }

        public frmExportView()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmExportView_Load(object sender, EventArgs e)
        {
            txtExportData.Text = ShowText;
        }
    }
}