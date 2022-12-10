using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Lab_8
{
    class TrippleDESCryptography
    {
        public static byte[] Encrypt(string Data, byte[] Key, byte[] IV)
        {
            try
            {
                MemoryStream mStream = new MemoryStream();

                CryptoStream cStream = new CryptoStream(mStream,
                    new TripleDESCryptoServiceProvider().CreateEncryptor(Key, IV),
                    CryptoStreamMode.Write);

                byte[] toEncrypt = new ASCIIEncoding().GetBytes(Data);

                cStream.Write(toEncrypt, 0, toEncrypt.Length);
                cStream.FlushFinalBlock();

                byte[] ret = mStream.ToArray();

                cStream.Close();
                mStream.Close();

                return ret;
            }
            catch (CryptographicException e)
            {
                Console.WriteLine("A Cryptographic error occurred: {0}", e.Message);
                return null;
            }
        }

        public static string Decrypt(byte[] Data, byte[] Key, byte[] IV)
        {
            try
            {
                MemoryStream msDecrypt = new MemoryStream(Data);

                CryptoStream csDecrypt = new CryptoStream(msDecrypt,
                    new TripleDESCryptoServiceProvider().CreateDecryptor(Key, IV),
                    CryptoStreamMode.Read);

                byte[] fromEncrypt = new byte[Data.Length];

                csDecrypt.Read(fromEncrypt, 0, fromEncrypt.Length);

                return new ASCIIEncoding().GetString(fromEncrypt);
            }
            catch (CryptographicException e)
            {
                Console.WriteLine("A Cryptographic error occurred: {0}", e.Message);
                return null;
            }
        }
    }
}
