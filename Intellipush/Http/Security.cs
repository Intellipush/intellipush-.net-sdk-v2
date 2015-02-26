using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Intellipush.Http
{
    class Security
    {
        public static string EncodeBase64(byte[] decbuff)
        {
            var encbuff = Convert.ToBase64String(decbuff);
            return encbuff;
        }

        public static byte[] DecodeBase64(string str)
        {
            var decbuff = Convert.FromBase64String(str);
            return decbuff;
        }

        public static String DecryptRJ256(string base64String, string KeyString, string IVString)
        {
            byte[] cypher = DecodeBase64(base64String);
            var sRet = "";

            var encoding = new UTF8Encoding();
            var Key = encoding.GetBytes(KeyString);
            var IV = encoding.GetBytes(IVString);

            using (var rj = new RijndaelManaged())
            {
                try
                {
                    rj.Padding = PaddingMode.Zeros;
                    rj.Mode = CipherMode.CBC;
                    rj.KeySize = 256;
                    rj.BlockSize = 256;
                    rj.Key = Key;
                    rj.IV = IV;
                    var ms = new MemoryStream(cypher);

                    using (var cs = new CryptoStream(ms, rj.CreateDecryptor(Key, IV), CryptoStreamMode.Read))
                    {
                        using (var sr = new StreamReader(cs))
                        {
                            sRet = sr.ReadLine();
                        }
                    }
                }
                finally
                {
                    rj.Clear();
                }
            }

            return sRet;
        }

        public static String EncryptRJ256(string stringToEncrypt, string KeyString, string IVString)
        {
            byte[] cypher;
            var encoding = new UTF8Encoding();
            var Key = encoding.GetBytes(KeyString);
            var IV = encoding.GetBytes(IVString);

            using (var rj = new RijndaelManaged())
            {
                try
                {
                    rj.Padding = PaddingMode.Zeros;
                    rj.Mode = CipherMode.CBC;
                    rj.KeySize = 256;
                    rj.BlockSize = 256;
                    rj.Key = Key;
                    rj.IV = IV;

                    var ms = new MemoryStream();

                    using (var cs = new CryptoStream(ms, rj.CreateEncryptor(Key, IV), CryptoStreamMode.Write))
                    {
                        var toEncrypt = Encoding.ASCII.GetBytes(stringToEncrypt);
                        cs.Write(toEncrypt, 0, toEncrypt.Length);
                        cs.FlushFinalBlock();
                        cypher = ms.ToArray();
                    }
                }
                finally
                {
                    rj.Clear();
                }
            }
            return HttpUtility.UrlEncode( EncodeBase64(cypher) );
        }
    }
}
