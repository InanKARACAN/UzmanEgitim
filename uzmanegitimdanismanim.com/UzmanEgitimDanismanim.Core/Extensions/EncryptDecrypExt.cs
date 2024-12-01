using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace UzmanEgitimDanismanim.Core.Extensions
{
    public static class EncryptDecrypExt
    {
        private static byte[] _key;

        private static byte[] _iv;

        public static byte[] Key
        {
            get
            {
                var key = "Uzman";
                _key = new byte[16];

                for (var i = 0; i < key.Length; i++) _key[i] = Convert.ToByte(key[i]);

                return _key;
            }
        }

        public static byte[] IV
        {
            get
            {
                var iv = "Egitim";
                _iv = new byte[16];

                for (var i = 0; i < iv.Length; i++) _iv[i] = Convert.ToByte(iv[i]);
                return _iv;
            }
        }

        public static string Encrypt(this int intValue)
        {
            var clearText = intValue.ToString();

            var algorithm = new RijndaelManaged();

            using (var memStream = new MemoryStream())
            {
                var transform = algorithm.CreateEncryptor(Key, IV);

                using (var cryptoStream = new CryptoStream(memStream, transform, CryptoStreamMode.Write))
                {
                    using (var strWriter = new StreamWriter(cryptoStream))
                    {
                        strWriter.Write(clearText);

                        strWriter.Flush();
                        cryptoStream.FlushFinalBlock();

                        var pwdStr = Convert.ToBase64String(memStream.ToArray());

                        return pwdStr;
                    }
                }
            }
        }

        public static string Decrypt(this string text)
        {
            var newText = text.Replace("%2B", "+").Replace(" ", "+").Replace("%3D", "=").Replace("%2F", "/").Replace("%2b", "+")
                .Replace("%3d", "=").Replace("%2f", "/");

            var algorithm = new RijndaelManaged();
            var buffer = Convert.FromBase64String(newText);

            using (var memStream = new MemoryStream(buffer, 0, buffer.Length))
            {
                var transform = algorithm.CreateDecryptor(Key, IV);

                memStream.Position = 0;

                using (var crStream = new CryptoStream(memStream, transform, CryptoStreamMode.Read))
                {
                    using (var strReader = new StreamReader(crStream, Encoding.UTF8))
                    {
                        var result = strReader.ReadToEnd().Replace("_", "-");
                        return result;
                    }
                }
            }
        }

        public static string EncryptStr(string text)
        {
            var algorithm = new RijndaelManaged();

            //algorithm.BlockSize = 256;
            //algorithm.KeySize = 256;

            using (var memStream = new MemoryStream())
            {
                var transform = algorithm.CreateEncryptor(Key, IV);

                using (var cryptoStream = new CryptoStream(memStream, transform, CryptoStreamMode.Write))
                {
                    using (var strWriter = new StreamWriter(cryptoStream))
                    {
                        strWriter.Write(text);

                        strWriter.Flush();
                        cryptoStream.FlushFinalBlock();

                        var pwdStr = Convert.ToBase64String(memStream.ToArray());

                        pwdStr = pwdStr.Replace("+", "%2B").Replace("=", "%3D").Replace("/", "%2F").Replace("+", "%2b").Replace("=", "%3d").Replace("/", "%2f");

                        return pwdStr;
                    }
                }
            }
        }

    }
}
