using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace CertKeyView
{
    class CryptoUtils
    {
        #region TripleDESDecrypt 3DES解密
        /// <summary>
        /// 3DES解密
        /// </summary>
        /// <param name="decryptSource">解密的数据源</param>
        /// <param name="decryptKey">解密的密匙</param>
        /// <param name="decryptIV">解密的矢量</param>
        /// <param name="paddingMode">填充模式</param>
        /// <param name="cipherMode">CBC/EBC</param>
        ///  <param name="outType">解密字节形式ToHex16,ToBase64</param>
        /// <returns>解密串</returns>
        public static string TripleDESDecrypt(string decryptSource, string decryptKey, string decryptIV,
            System.Security.Cryptography.PaddingMode paddingMode, System.Security.Cryptography.CipherMode cipherMode, string outType)
        {
            if (string.IsNullOrEmpty(outType))
            {
                throw new Exception("输出配置不能空");
            }
            if (decryptKey.Length != 24)
            {
                throw new Exception("密钥字节长度不对");
            }
            try
            {
                //构造一个对称算法
                SymmetricAlgorithm mCSP = new TripleDESCryptoServiceProvider();
                byte[] Key = System.Text.Encoding.UTF8.GetBytes(decryptKey.Trim());

                mCSP.Key = Key;
                //默认矢量
                if (String.IsNullOrEmpty(decryptIV))
                {
                    decryptIV = decryptKey.Substring(0, 8);
                }
                mCSP.IV = System.Text.Encoding.UTF8.GetBytes(decryptIV);

                mCSP.Mode = cipherMode;
                mCSP.Padding = paddingMode;

                ICryptoTransform ct = mCSP.CreateDecryptor(mCSP.Key, mCSP.IV);

                byte[] byt = new byte[0];

                //输出ToBase64字符
                if (outType == "ToBase64")
                {
                    byt = Convert.FromBase64String(decryptSource);
                }
                //输出16进制字符
                else //if (outType == "ToHex16")
                {
                    byt = ConvertHexToBytes(decryptSource);
                }
                using (MemoryStream ms = new MemoryStream())
                {
                    CryptoStream cs = new CryptoStream(ms, ct, CryptoStreamMode.Write);
                    cs.Write(byt, 0, byt.Length);
                    cs.FlushFinalBlock();
                    cs.Close();

                    return Encoding.UTF8.GetString(ms.ToArray()).Replace("\0", "").Trim();
                }
            }
            catch (Exception ex)
            {
                //log.Warn("TripleDES解密发生错误,原因：" + ex.Message);// + MessageUtils.GetExceptionSrcStackTraceLog(ex));
                throw new Exception("解密发生错误,原因：" + ex.Message, ex);
            }
        }
        #endregion

        #region TripleDESEncrypt 3DES加密
        /// <summary>
        /// 3DES加密
        /// </summary>
        /// <param name="encryptSource">加密的数据源</param>
        /// <param name="encryptKey">加密的密匙</param>
        /// <param name="decryptIV">加密的矢量</param>
        /// <param name="paddingMode">填充模式</param>
        /// <param name="cipherMode">CBC/EBC</param>
        ///  <param name="outType">加密字节形式ToHex16,ToBase64</param>
        /// <returns>加密串</returns>
        public static string TripleDESEncrypt(string encryptSource, string encryptKey, string decryptIV,
            System.Security.Cryptography.PaddingMode paddingMode, System.Security.Cryptography.CipherMode cipherMode, string outType)
        {
            if (string.IsNullOrEmpty(outType))
            {
                throw new Exception("输出配置不能空");
            }
            if (encryptKey.Length != 24)
            {
                throw new Exception("密钥字节长度不对");
            }
            try
            {
                //构造一个对称算法
                SymmetricAlgorithm mCSP = new TripleDESCryptoServiceProvider();
                byte[] Key = System.Text.Encoding.UTF8.GetBytes(encryptKey.Trim());

                mCSP.Key = Key;
                //默认矢量
                if (String.IsNullOrEmpty(decryptIV))
                {
                    decryptIV = encryptKey.Substring(0, 8);
                }
                mCSP.IV = System.Text.Encoding.UTF8.GetBytes(decryptIV);

                mCSP.Mode = cipherMode;
                mCSP.Padding = paddingMode;

                ICryptoTransform ct = mCSP.CreateEncryptor(mCSP.Key, mCSP.IV);

                byte[] byt = Encoding.UTF8.GetBytes(encryptSource);

                using (MemoryStream ms = new MemoryStream())
                {
                    CryptoStream cs = new CryptoStream(ms, ct, CryptoStreamMode.Write);
                    cs.Write(byt, 0, byt.Length);
                    cs.FlushFinalBlock();
                    cs.Close();

                    //return Encoding.UTF8.GetString(ms.ToArray()).Replace("\0", "").Trim();
                    //输出16进制字符
                    //if (outType == "ToHex16")
                    //{
                    //    byt = CryptoUtils.Convert(decryptSource);
                    //}
                    //输出ToBase64字符
                    if (outType == "ToBase64")
                    {
                        return Convert.ToBase64String(ms.ToArray());
                    }

                    return ByteArrayToHexString(ms.ToArray());
                }


            }
            catch (Exception ex)
            {
                //log.Warn("TripleDES解密发生错误,原因：" + ex.Message);// + MessageUtils.GetExceptionSrcStackTraceLog(ex));
                throw new Exception("解密发生错误,原因：" + ex.Message, ex);
            }
        }
        #endregion

        #region MD5加密
        /// <summary>
        ///  MD5加密
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string MD5(string data)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] output = md5.ComputeHash(System.Text.Encoding.UTF8.GetBytes(data));
            return BitConverter.ToString(output).Replace("-", "").ToLower(); 
        }
        #endregion

        #region ByteArrayToHexString
        /// <summary>
        /// 将二进制数组转变为字符串
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string ByteArrayToHexString(byte[] data)
        {
            return BitConverter.ToString(data).Replace("-", "").ToLower();
        }
        #endregion

        #region ConvertHexToBytes
        /// <summary>
        /// 将字符串转变为二进制数组
        /// </summary>
        /// <param name="hexString"></param>
        /// <returns></returns>
        public static byte[] ConvertHexToBytes(string hexString)
        {
            try
            {
                if (string.IsNullOrEmpty(hexString))
                {
                    return null;
                }
                int len = hexString.Length / 2;
                byte[] bytes = new byte[len];
                for (int i = 0; i < len; i++)
                {
                    bytes[i] = (byte)(Convert.ToInt32(hexString.Substring(i * 2, 2), 16));
                }
                return bytes;
            }
            catch (Exception)
            {
                //log.Debug(ex);
                return null;
            }
        }
        #endregion

        #region 

        internal static string ExportCertificate(X509Certificate2 certificate, bool bEncrypt)
        {
            string pubKeyStr = "";
            string privateKeyStr = "";

            if (certificate.PrivateKey != null)
                privateKeyStr = certificate.PrivateKey.ToXmlString(true);
            else
                privateKeyStr = "";

            byte[] rawData = certificate.Export(X509ContentType.Cert);
            pubKeyStr = StringUtils.ByteArrayToHexString(rawData);

            StringBuilder sb = new StringBuilder();
            sb.Append("  <parameter key=\"guid\" value=\"");
            sb.Append(System.Guid.NewGuid().ToString().Replace("-", "").ToUpper());
            sb.Append("\"/>");
            sb.Append("\r\n");
            sb.Append("  <parameter key=\"RsaPublicKey\" value=\"");
            if (bEncrypt)
            {
                sb.Append(pubKeyStr);
            }
            else
            {
                sb.Append(pubKeyStr);
            }
            sb.Append("\"/>");
            sb.Append("\r\n");
            sb.Append("  <parameter key=\"RsaPrivateKey\" value=\"");
            string str = privateKeyStr.Replace("<", "&lt;").Replace(">", "&gt;");
            if (bEncrypt)
            {
                sb.Append(str);
            }
            else
            {
                sb.Append(str);
            }
            sb.Append("\"/>");
            sb.Append("\r\n");

            return sb.ToString();
        }

        #endregion
    }
}
