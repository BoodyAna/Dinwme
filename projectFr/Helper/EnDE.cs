using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace projectFr.Helper
{
    public static class EnDE
    {
            private const string _encryptDecryptPass = "ad9239f4-d200-4bf9-9022-3aa654c847c0";
            public static string Encrypt(string data)
            {
                byte[] encryptedBytes;
                using (var sha256 = SHA256.Create())
                {
                    var sha256Key = sha256.ComputeHash(Encoding.UTF8.GetBytes(_encryptDecryptPass));
                    using (var aes = Aes.Create())
                    {
                        aes.Key = sha256Key;
                        aes.Mode = CipherMode.ECB;
                        aes.Padding = PaddingMode.PKCS7;
                        var dataBytes = Encoding.UTF8.GetBytes(data);
                        try
                        {
                            ICryptoTransform encryptor = aes.CreateEncryptor();
                            encryptedBytes = encryptor.TransformFinalBlock(dataBytes, 0, dataBytes.Length);
                        }
                        finally
                        {
                            aes.Clear();
                        }
                    }
                }
                return Convert.ToBase64String(encryptedBytes);
            }
            public static string Decrypt(string data)
            {
                byte[] decryptedBytes;
                using (var sha256 = SHA256.Create())
                {
                    var sha256Key = sha256.ComputeHash(Encoding.UTF8.GetBytes(_encryptDecryptPass));
                    using (var aes = Aes.Create())
                    {
                        aes.Key = sha256Key;
                        aes.Mode = CipherMode.ECB;
                        aes.Padding = PaddingMode.PKCS7;   
                        try
                        {
                        var dataBytes = Convert.FromBase64String(data);
                        ICryptoTransform decryptor = aes.CreateDecryptor();
                            decryptedBytes = decryptor.TransformFinalBlock(dataBytes, 0, dataBytes.Length);
                        }
                        finally
                        {
                        aes.Clear();
                        
                    }
                    }
                }
                return Encoding.UTF8.GetString(decryptedBytes);
            }
    }
}
