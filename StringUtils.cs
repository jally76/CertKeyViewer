using System;
using System.Collections.Generic;
using System.Text;

namespace CertKeyView
{
    class StringUtils
    {
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
