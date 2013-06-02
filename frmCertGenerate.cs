using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography;

namespace CertKeyView
{
    public partial class frmCertGenerate : Form
    {
        public class ComboBoxItem
        {
            public ComboBoxItem(string txt, string val, int location)
            {
                _text = txt;
                _value = val;
                _location = location;
            }

            private string _text = null;
            private object _value = null;
            private int _location = 0;

            public string Text { get { return this._text; } set { this._text = value; } }
            public object Value { get { return this._value; } set { this._value = value; } }
            public int Location { get { return this._location; } set { this._location = value; } }
            public override string ToString()
            {
                return this._text;
            }
        }

        public frmCertGenerate()
        {
            InitializeComponent();
        }

        private void frmCertGenerate_Load(object sender, EventArgs e)
        {
        }

        private void btnGenerateCert_Click(object sender, EventArgs e)
        {
            byte[] pfxData = Certificate.CreateSelfSignCertificatePfx("CN=" + txtCertName.Text,
                DateTime.Now, DateTime.Now.AddYears(30), "abcTest");
            //MessageBox.Show(StringUtils.ByteArrayToHexString(pfxData));

            X509Store store = null;
            try
            {
                if (chkSaveInCurrentUser.Checked)
                    store = new X509Store(StoreName.My, StoreLocation.CurrentUser);
                else
                    store = new X509Store(StoreName.My, StoreLocation.LocalMachine);

                store.Open(OpenFlags.ReadWrite);

                X509Certificate2 pc = new X509Certificate2(pfxData, "abcTest", X509KeyStorageFlags.Exportable);
                store.Add(pc);

                store.Close();

                ShowExportData(pc);
            }
            finally
            {
                if (store != null)
                    store.Close();
            }

        }

        private void ShowExportData(X509Certificate2 certificate)
        {
            try
            {
                string str = CryptoUtils.ExportCertificate(certificate, chkEncryptExport.Checked); 

                txtExportData.Text = str;
            }
            catch (Exception ex)
            {
                MessageBox.Show("≥ˆœ÷¿˝Õ‚£∫" + ex.Message + "\r\n" + ex.StackTrace, 
                    certificate.FriendlyName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}