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
            public ComboBoxItem(string txt, string val)
            {
                _text = txt;
                _value = val;
            }

            private string _text = null;
            private object _value = null;
            public string Text { get { return this._text; } set { this._text = value; } }
            public object Value { get { return this._value; } set { this._value = value; } }
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
                cboCertList.Items.Add(new ComboBoxItem(name, name));
            }
            store.Close();
        }

        private void cboCertList_SelectedValueChanged(object sender, EventArgs e)
        {
            OnSelectedItemRefresh();
        }

        private void OnSelectedItemRefresh()
        {
            string cert = (cboCertList.SelectedItem as ComboBoxItem).Value as string;

            X509Store store = new X509Store(StoreName.My, StoreLocation.LocalMachine);
            store.Open(OpenFlags.ReadOnly);
            foreach (X509Certificate2 certificate in store.Certificates)
            {
                string name = certificate.GetNameInfo(X509NameType.SimpleName, false);
                if (name.Equals(cert))
                {
                    txtPrivateKey.Text = certificate.PrivateKey.ToXmlString(chkContainsPrivate.Checked);

                    string pubKeyStr = "";
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
                        pubKeyStr = ByteArrayToHexString(rawData);
                    }
                    else
                    {
                        pubKeyStr = certificate.PublicKey.EncodedKeyValue.Format(false);
                    }

                    txtPublicKey.Text = pubKeyStr;
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

        #region ByteArrayToHexString 字节数组转换到十六制的字符串，例如：68 56 01 56 01 68
        /// <summary>
        /// 字节数组转换到十六制的字符串，例如：68 56 01 56 01 68
        /// </summary>
        /// <param name="data"></param>
        /// <returns>例如：68 56 01 56 01 68</returns>
        public static string ByteArrayToHexString(byte[] data)
        {
            if (data == null)
                return null;
            return ByteArrayToHexString(data, 0, data.Length, '\0');
        }

        /// <summary>
        /// 字节数组转换到十六制的字符串，例如：68 56 01 56 01 68
        /// </summary>
        /// <param name="data"></param>
        /// <param name="splitChar">' ', ', ', 或者为空</param>
        /// <returns>例如：68 56 01 56 01 68</returns>
        public static string ByteArrayToHexString(byte[] data, char splitChar)
        {
            if (data == null)
                return null;

            return ByteArrayToHexString(data, 0, data.Length, splitChar);
        }

        /// <summary>
        /// 字节数组转换到十六制的字符串，例如：68 56 01 56 01 68
        /// </summary>
        /// <param name="data"></param>
        /// <param name="offset"></param>
        /// <param name="len"></param>
        /// <param name="splitChar">' ', ', ', 或者为空</param>
        /// <returns>例如：68 56 01 56 01 68</returns>
        public static string ByteArrayToHexString(byte[] data, int offset, int len, char splitChar)
        {
            if (data == null)
                return null;

            string str = BitConverter.ToString(data, offset, len);
            if (splitChar != '\0')
                str = str.Replace('-', splitChar);
            else
                str = str.Replace("-", "");
            return str.ToLower();
        }
        #endregion
    }
}