using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography.X509Certificates;
using System.Diagnostics;
using System.IO;

namespace CertKeyView
{
    // C#��������֤�鲢����Ϊpfx����ʹ��pfx���зǶԳƼӽ��� http://blog.csdn.net/luminji/article/details/3960308
    // ����Դ�������أ�http://download.csdn.net/source/2444494 
    //      1������.NET2.0��MAKECERT��������˽Կ������֤�飬���洢������֤������
    //      2������֤�鵼��Ϊpfx�ļ�����Ϊ��ָ��һ��������pfx�ļ���password��
    //      3����ȡpfx�ļ�������pfx�й�Կ��˽Կ��
    //      4����pfx֤���еĹ�Կ�������ݵļ��ܣ���˽Կ�������ݵĽ��ܣ�
    internal sealed class Certificate2
    {
        #region ����֤��
        /// <summary>  
        /// ����ָ����֤������makecertȫ·������֤�飨������Կ��˽Կ����������MY�洢����  
        /// </summary>  
        /// <param name="subjectName"></param>  
        /// <param name="makecertPath"></param>  
        /// <returns></returns>  
        public static bool CreateCertWithPrivateKey(string subjectName, string makecertPath)  
        {  
            subjectName = "CN=" + subjectName;  
            string param = " -pe -ss my -n \"" + subjectName + "\" ";  
            try  
            {  
                Process p = Process.Start(makecertPath, param);  
                p.WaitForExit();  
                p.Close();  
            }  
            catch (Exception e)  
            {  
                //LogRecord.putErrorLog(e.ToString(), "DataCerficate.CreateCertWithPrivateKey");  
                return false;  
            }  
            return true;  
        }
        #endregion

        #region �ļ����뵼��
        /// <summary>  
        /// ��WINDOWS֤��洢���ĸ���MY���ҵ�����ΪsubjectName��֤�飬  
        /// ������Ϊpfx�ļ���ͬʱΪ��ָ��һ������  
        /// ����֤��Ӹ�����ɾ��(���isDelFromstorΪtrue)  
        /// </summary>  
        /// <param name="subjectName">֤�����⣬������CN=</param>  
        /// <param name="pfxFileName">pfx�ļ���</param>  
        /// <param name="password">pfx�ļ�����</param>  
        /// <param name="isDelFromStore">�Ƿ�Ӵ洢��ɾ��</param>  
        /// <returns></returns>  
        public static bool ExportToPfxFile(string subjectName, string pfxFileName,
            string password, bool isDelFromStore)
        {
            subjectName = "CN=" + subjectName;
            X509Store store = new X509Store(StoreName.My, StoreLocation.CurrentUser);
            store.Open(OpenFlags.ReadWrite);
            X509Certificate2Collection storecollection = (X509Certificate2Collection)store.Certificates;
            foreach (X509Certificate2 x509 in storecollection)
            {
                if (x509.Subject == subjectName)
                {
                    Debug.Print(string.Format("certificate name: {0}", x509.Subject));

                    byte[] pfxByte = x509.Export(X509ContentType.Pfx, password);
                    using (FileStream fileStream = new FileStream(pfxFileName, FileMode.Create))
                    {
                        // Write the data to the file, byte by byte.  
                        for (int i = 0; i < pfxByte.Length; i++)
                            fileStream.WriteByte(pfxByte[i]);
                        // Set the stream position to the beginning of the file.  
                        fileStream.Seek(0, SeekOrigin.Begin);
                        // Read and verify the data.  
                        for (int i = 0; i < fileStream.Length; i++)
                        {
                            if (pfxByte[i] != fileStream.ReadByte())
                            {
                                //LogRecord.putErrorLog("Export pfx error while verify the pfx file!", "ExportToPfxFile");
                                fileStream.Close();
                                return false;
                            }
                        }
                        fileStream.Close();
                    }
                    if (isDelFromStore == true)
                        store.Remove(x509);
                }
            }
            store.Close();
            store = null;
            storecollection = null;
            return true;
        }
        /// <summary>  
        /// ��WINDOWS֤��洢���ĸ���MY���ҵ�����ΪsubjectName��֤�飬  
        /// ������ΪCER�ļ�������ֻ����Կ�ģ�  
        /// </summary>  
        /// <param name="subjectName"></param>  
        /// <param name="cerFileName"></param>  
        /// <returns></returns>  
        public static bool ExportToCerFile(string subjectName, string cerFileName)
        {
            subjectName = "CN=" + subjectName;
            X509Store store = new X509Store(StoreName.My, StoreLocation.CurrentUser);
            store.Open(OpenFlags.ReadWrite);
            X509Certificate2Collection storecollection = (X509Certificate2Collection)store.Certificates;
            foreach (X509Certificate2 x509 in storecollection)
            {
                if (x509.Subject == subjectName)
                {
                    Debug.Print(string.Format("certificate name: {0}", x509.Subject));
                    //byte[] pfxByte = x509.Export(X509ContentType.Pfx, password);  
                    byte[] cerByte = x509.Export(X509ContentType.Cert);
                    using (FileStream fileStream = new FileStream(cerFileName, FileMode.Create))
                    {
                        // Write the data to the file, byte by byte.  
                        for (int i = 0; i < cerByte.Length; i++)
                            fileStream.WriteByte(cerByte[i]);
                        // Set the stream position to the beginning of the file.  
                        fileStream.Seek(0, SeekOrigin.Begin);
                        // Read and verify the data.  
                        for (int i = 0; i < fileStream.Length; i++)
                        {
                            if (cerByte[i] != fileStream.ReadByte())
                            {
                                //LogRecord.putErrorLog("Export CER error while verify the CERT file!", "ExportToCERFile");
                                fileStream.Close();
                                return false;
                            }
                        }
                        fileStream.Close();
                    }
                }
            }
            store.Close();
            store = null;
            storecollection = null;
            return true;
        }
        #endregion

        #region ��֤���л�ȡ��Ϣ
        /// <summary>  
        /// ����˽Կ֤��õ�֤��ʵ�壬�õ�ʵ�����Ը����乫Կ��˽Կ���мӽ���  
        /// �ӽ��ܺ���ʹ��DEncrypt��RSACryption��  
        /// </summary>  
        /// <param name="pfxFileName"></param>  
        /// <param name="password"></param>  
        /// <returns></returns>  
        public static X509Certificate2 GetCertificateFromPfxFile(string pfxFileName,
            string password)
        {
            try
            {
                return new X509Certificate2(pfxFileName, password, X509KeyStorageFlags.Exportable);
            }
            catch (Exception e)
            {
                //LogRecord.putErrorLog("get certificate from pfx" + pfxFileName + " error:" + e.ToString(), "GetCertificateFromPfxFile");
                return null;
            }
        }
        /// <summary>  
        /// ���洢����ȡ֤��  
        /// </summary>  
        /// <param name="subjectName"></param>  
        /// <returns></returns>  
        public static X509Certificate2 GetCertificateFromStore(string subjectName)
        {
            subjectName = "CN=" + subjectName;
            X509Store store = new X509Store(StoreName.My, StoreLocation.CurrentUser);
            store.Open(OpenFlags.ReadWrite);
            X509Certificate2Collection storecollection = (X509Certificate2Collection)store.Certificates;
            foreach (X509Certificate2 x509 in storecollection)
            {
                if (x509.Subject == subjectName)
                {
                    return x509;
                }
            }
            store.Close();
            store = null;
            storecollection = null;
            return null;
        }
        /// <summary>  
        /// ���ݹ�Կ֤�飬����֤��ʵ��  
        /// </summary>  
        /// <param name="cerPath"></param>  
        public static X509Certificate2 GetCertFromCerFile(string cerPath)
        {
            try
            {
                return new X509Certificate2(cerPath);
            }
            catch (Exception e)
            {
                //LogRecord.putErrorLog(e.ToString(), "Certificate2.LoadStudentPublicKey");
                return null;
            }
        }
        #endregion
    }
}
