using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography.X509Certificates;

namespace CertKeyView
{
    public partial class frmCertKeyView : Form
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

        public frmCertKeyView()
        {
            InitializeComponent();
        }

        private void frmCertKeyView_Load(object sender, EventArgs e)
        {
            LoadCertificateList();
            if (cboCertList.Items.Count > 0)
            {
                cboCertList.SelectedIndex = 0;
                OnSelectedItemRefresh();
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadCertificateList();
        }

        private void LoadCertificateList()
        {
            cboCertList.Items.Clear();

            X509Store store = new X509Store(StoreName.My, StoreLocation.LocalMachine);
            store.Open(OpenFlags.ReadOnly);
            foreach (X509Certificate2 certificate in store.Certificates)
            {
                string name = certificate.GetNameInfo(X509NameType.SimpleName, false);
                cboCertList.Items.Add(new ComboBoxItem(name, name, 1));
            }
            store.Close();

            store = new X509Store(StoreName.My, StoreLocation.CurrentUser);
            store.Open(OpenFlags.ReadOnly);
            foreach (X509Certificate2 certificate in store.Certificates)
            {
                string name = certificate.GetNameInfo(X509NameType.SimpleName, false);
                cboCertList.Items.Add(new ComboBoxItem(name, name, 2));
            }
            store.Close();
        }

        private void cboCertList_SelectedValueChanged(object sender, EventArgs e)
        {
            OnSelectedItemRefresh();
        }

        private void OnSelectedItemRefresh()
        {
            ComboBoxItem item = (cboCertList.SelectedItem as ComboBoxItem);
            string cert = item.Value as string;

            X509Store store = null;
            if( item.Location == 1 )
                store = new X509Store(StoreName.My, StoreLocation.LocalMachine);
            else if(item.Location == 2)
                store = new X509Store(StoreName.My, StoreLocation.CurrentUser);
            store.Open(OpenFlags.ReadOnly);
            foreach (X509Certificate2 certificate in store.Certificates)
            {
                string name = certificate.GetNameInfo(X509NameType.SimpleName, false);
                if (name.Equals(cert))
                {
                    string pubKeyStr = "";
                    string privateKeyStr = "";

                    try
                    {
                        if (certificate.PrivateKey != null)
                            privateKeyStr = certificate.PrivateKey.ToXmlString(chkContainsPrivate.Checked);
                        else
                            privateKeyStr = "";

                        if (chkPubShowString.Checked)
                        {
                            //byte[] rawData = certificate.PublicKey.EncodedKeyValue.RawData;
                            //if (rawData[5] == 0x81)
                            //{
                            //    byte[] rawData0 = rawData;
                            //    rawData = new byte[128];
                            //    Array.Copy(rawData0, 7, rawData, 0, 128);
                            //}
                            //else if (rawData[5] == 0x80)
                            //{
                            //    byte[] rawData0 = rawData;
                            //    rawData = new byte[128];
                            //    Array.Copy(rawData0, 6, rawData, 0, 128);
                            //}

                            byte[] rawData = certificate.Export(X509ContentType.Cert);
                            pubKeyStr = StringUtils.ByteArrayToHexString(rawData);
                        }
                        else
                        {
                            pubKeyStr = certificate.PublicKey.EncodedKeyValue.Format(false);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("出现例外：" + ex.Message + "\r\n" + ex.StackTrace, "" + name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    txtPublicKey.Text = pubKeyStr;
                    txtPrivateKey.Text = privateKeyStr;
                    break;
                }
            }
            store.Close();
        }

        private void chkContainsPrivate_CheckedChanged(object sender, EventArgs e)
        {
            OnSelectedItemRefresh();
        }

        private void chkPubShowString_CheckedChanged(object sender, EventArgs e)
        {
            OnSelectedItemRefresh();
        }

        private void btnGenerateCert_Click(object sender, EventArgs e)
        {
            frmCertGenerate frm = new frmCertGenerate();
            frm.ShowDialog(this);

            int pos = cboCertList.SelectedIndex;
            LoadCertificateList();
            if (cboCertList.Items.Count < pos)
            {
                pos = cboCertList.Items.Count - 1;
            }
            if (pos >= 0)
            {
                cboCertList.SelectedIndex = pos;
                OnSelectedItemRefresh();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            ComboBoxItem item = (cboCertList.SelectedItem as ComboBoxItem);
            string cert = item.Value as string;

            X509Store store = null;
            if (item.Location == 1)
                store = new X509Store(StoreName.My, StoreLocation.LocalMachine);
            else if (item.Location == 2)
                store = new X509Store(StoreName.My, StoreLocation.CurrentUser);

            store.Open(OpenFlags.ReadWrite);
            foreach (X509Certificate2 certificate in store.Certificates)
            {
                string name = certificate.GetNameInfo(X509NameType.SimpleName, false);
                if (name.Equals(cert))
                {
                    store.Remove(certificate);
                    break;
                }
            }
            store.Close();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            ComboBoxItem item = (cboCertList.SelectedItem as ComboBoxItem);
            string cert = item.Value as string;

            X509Store store = null;
            if (item.Location == 1)
                store = new X509Store(StoreName.My, StoreLocation.LocalMachine);
            else if (item.Location == 2)
                store = new X509Store(StoreName.My, StoreLocation.CurrentUser);

            store.Open(OpenFlags.ReadOnly);
            foreach (X509Certificate2 certificate in store.Certificates)
            {
                string name = certificate.GetNameInfo(X509NameType.SimpleName, false);
                if (name.Equals(cert))
                {
                    try
                    {
                        string str = CryptoUtils.ExportCertificate(certificate, chkEncryptExport.Checked);

                        frmExportView dlg = new frmExportView();
                        dlg.ShowText = str;
                        dlg.Show(this);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("出现例外：" + ex.Message + "\r\n" + ex.StackTrace, "" + name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    
                    break;
                }
            }
            store.Close();
        }

    }
}