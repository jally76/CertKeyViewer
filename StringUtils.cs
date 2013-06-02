using System;
using System.Collections.Generic;
using System.Text;

namespace CertKeyView
{
    class StringUtils
    {
        #region ByteArrayToHexString �ֽ�����ת����ʮ���Ƶ��ַ��������磺68 56 01 56 01 68
        /// <summary>
        /// �ֽ�����ת����ʮ���Ƶ��ַ��������磺68 56 01 56 01 68
        /// </summary>
        /// <param name="data"></param>
        /// <returns>���磺68 56 01 56 01 68</returns>
        public static string ByteArrayToHexString(byte[] data)
        {
            if (data == null)
                return null;
            return ByteArrayToHexString(data, 0, data.Length, '\0');
        }

        /// <summary>
        /// �ֽ�����ת����ʮ���Ƶ��ַ��������磺68 56 01 56 01 68
        /// </summary>
        /// <param name="data"></param>
        /// <param name="splitChar">' ', ', ', ����Ϊ��</param>
        /// <returns>���磺68 56 01 56 01 68</returns>
        public static string ByteArrayToHexString(byte[] data, char splitChar)
        {
            if (data == null)
                return null;

            return ByteArrayToHexString(data, 0, data.Length, splitChar);
        }

        /// <summary>
        /// �ֽ�����ת����ʮ���Ƶ��ַ��������磺68 56 01 56 01 68
        /// </summary>
        /// <param name="data"></param>
        /// <param name="offset"></param>
        /// <param name="len"></param>
        /// <param name="splitChar">' ', ', ', ����Ϊ��</param>
        /// <returns>���磺68 56 01 56 01 68</returns>
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
