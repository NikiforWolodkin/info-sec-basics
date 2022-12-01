using System;
using System.Security.Cryptography;
using System.Text;

class RSASign
{
    static void Main()
    {
        try
        {
            UTF8Encoding ByteConverter = new UTF8Encoding();

            Console.Write("Введите сообщение: ");
            string dataString = Console.ReadLine();

            byte[] originalData = ByteConverter.GetBytes(dataString);
            byte[] signedData;

            RSACryptoServiceProvider RSAalg = new RSACryptoServiceProvider();

            RSAParameters Key = RSAalg.ExportParameters(true);

            signedData = HashAndSignBytes(originalData, Key);

            if (VerifySignedHash(originalData, signedData, Key))
            {
                Console.WriteLine("ЭЦП принадлежит этому сообщению");
            }
            else
            {
                Console.WriteLine("ЭЦП не принадлежит этому сообщению");
            }
        }
        catch (ArgumentNullException)
        {
            Console.WriteLine("ЭЦП не проверено");
        }
    }
    public static byte[] HashAndSignBytes(byte[] DataToSign, RSAParameters Key)
    {
        try
        {
            RSACryptoServiceProvider RSAalg = new RSACryptoServiceProvider();

            RSAalg.ImportParameters(Key);

            return RSAalg.SignData(DataToSign, SHA256.Create());
        }
        catch (CryptographicException e)
        {
            Console.WriteLine(e.Message);

            return null;
        }
    }

    public static bool VerifySignedHash(byte[] DataToVerify, byte[] SignedData, RSAParameters Key)
    {
        try
        {
            RSACryptoServiceProvider RSAalg = new RSACryptoServiceProvider();

            RSAalg.ImportParameters(Key);

            return RSAalg.VerifyData(DataToVerify, SHA256.Create(), SignedData);
        }
        catch (CryptographicException e)
        {
            Console.WriteLine(e.Message);

            return false;
        }
    }
}