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
            cboExportFormatType.SelectedIndex = 0;
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

        private string ConvertKeyToPem(X509Certificate2 certificate, bool bPrivate)
        {
            StringBuilder sb = new StringBuilder();

            if(bPrivate)
            {
                sb.Append("-----BEGIN RSA PRIVATE KEY-----").Append("\r\n");
            }
            else
            {
                sb.Append("-----BEGIN PUBLIC KEY-----").Append("\r\n");
            }

            if(bPrivate)
            {
                //sb.Append(certificate.PrivateKey..Format(true));
                //@to-do ??????????????? 类似于：
//-----BEGIN RSA PRIVATE KEY-----
//MIICWwIBAAKBgQC8KN0EpGLX8czymL417sALHfpxVSmpsJp62kFrIh/335mfQgL8
//QUi9XTHnhJLzo1/TnNVI9yxdjsAnXMWQ8kn8uCXihKVIsSGwY84IrxRCsiedAweF
//zWFNknKYITVH/jHDJZLmwV0CPJMFxi44LqUX5ZGNJ3hk1izpXiha/h8FawIDAQAB
//AoGAC0EmdzCd+OytpZUdS3yMYB3a7Qx7AXtewhpr70yLPPhS6AO6yfvdrfX1FjQH
//1irfgHjRCRw/uxjexXv3FURoyGqF6rYbUhDLBElocoPG+LCQxMs3fsM5I7Hh4PgE
//KLfL9FiXiQ6oiUZM5eYntZFd4oDWfyesjFIN95L2C0MJiwECQQD4iYBDoRXpPFHp
//kEXBA594hgp2BpFv7Qh6hABVVBJtsVGlqb9REwu6jv1KQD0M298oNHoiDaub3tRm
//i6GOmnODAkEAwc898TXR2/CH/AWabOxMAaJEchQn6PRXLo5GsWwh+bs1pMBLmwaS
//Rg2vd+f9rIgva0YWRnsuWPrn+duIxvm5+QJBAOyo2ecMC7Y1Bva1t4Yscfys/mcW
//qASBG/K1oS+fR5EGKO3rrk6AKUnzAINkmf2VnHBHUAj/JWreCzi+Ow90SQsCQGQA
//o12K/7YU7pXD7mK1qqJNMDQM4mr5aOLE1wVFXmKVjqBr+JcNVPyAo0GjmukjfBRG
//HchQVyHilT//XxwMT0ECP0kHw5L3gd9ORbj8cdtBDmUbdLLQAFW9mVnHfpkaivf2
//NBTg/f8v9uDti8pKbNvDwU/gs9wFKneJm3dUE5y/fA==
//-----END RSA PRIVATE KEY-----

            }
            else
            {
                //sb.Append(certificate.PublicKey.EncodedKeyValue.Format(false));
                byte[] data = certificate.PublicKey.EncodedKeyValue.RawData;
                byte[] data2 = GetPublicKeyEncoded(data);

                string str = Convert.ToBase64String(data2);
                for (int i = 0; i < str.Length; i += 64 )
                {
                    int count = str.Length - i;
                    if( count > 64 )
                    {
                        count = 64;
                    }
                    sb.Append(str.Substring(i, count)).Append("\r\n");
                }
            }
            //sb.Append("\r\n");

            if (bPrivate)
            {
                sb.Append("-----END RSA PRIVATE KEY-----").Append("\r\n");
            }
            else
            {
                sb.Append("-----END PUBLIC KEY-----").Append("\r\n");
            }

            return sb.ToString();
        }

        private byte[] DataToSequence(byte[] data, byte blockType)
        {
            int len1 = data.Length;
            if (blockType == 0x03)
            {
                len1++;
            }
            else if ((data[0] & 0x80) != 0)
            {
                len1++;
            }

            int len2 = len1 + 1;
            if (len1 > 127)
            {
                len2++;
            }
            if (len1 > 255)
            {
                len2++;
            }
            if (len1 > 0xFFFF)
            {
                return null;
            }

            byte[] result = new byte[len2 + 1];
            result[0] = blockType;
            if (len1 <= 127)
            {
                result[1] = (byte)len1;
            }
            else if (len1 <= 255)
            {
                result[1] = 0x81;
                result[2] = (byte)len1;
            }
            else
            {
                result[1] = 0x82;
                result[2] = (byte)(len1 / 256);
                result[3] = (byte)(len1 & 0xFF);
            }

            if (len1 != data.Length)
            {
                result[result.Length - len1] = 0;
            }

            Array.Copy(data, 0, result, result.Length - data.Length, data.Length);
            return result;
        }

        private byte[] CombineBlocks(byte[] block1, byte[] block2)
        {
            byte[] block = new byte[block1.Length + block2.Length];
            Array.Copy(block1, 0, block, 0, block1.Length);
            Array.Copy(block2, 0, block, block1.Length, block2.Length);
            byte[] result = DataToSequence(block, 0x30);
            return result;
        }

        private byte[] GetPublicKeyEncoded(byte[] dataBlock)
        {
            byte[] dataType = new byte[] { 0x30, 0x0D, 
                0x06, 0x09, 0x2A, 0x86, 0x48, 0x86, 0xF7, 0x0D, 0x01, 0x01, 0x01, 0x05, 0x00 };

            byte[] dataBlock2 = DataToSequence(dataBlock, 3);

            byte[] result = CombineBlocks(dataType, dataBlock2);
            return result;
        }



        private void OnSelectedItemRefresh()
        {
            ComboBoxItem item = (cboCertList.SelectedItem as ComboBoxItem);
            if (item == null)
                return;
            string cert = item.Value as string;

            bool bXmlPrivateString = cboExportFormatType.SelectedIndex == 0;

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
                        {
                            if (bXmlPrivateString)
                            {
                                privateKeyStr = certificate.PrivateKey.ToXmlString(chkContainsPrivate.Checked);
                            }
                            else
                            {
                                privateKeyStr = ConvertKeyToPem(certificate, chkContainsPrivate.Checked);
                            }
                        }
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

                        string rawCertDataString = certificate.GetRawCertDataString();
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

        private void cboExportFormatType_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnSelectedItemRefresh();
        }


    }
}