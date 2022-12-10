using System.Security.Cryptography;
using System.Text;
using Lab_8;

try
{
    TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider();
    tripleDES.KeySize = 192;

    string message = "Wolodkin";

    byte[] data = TrippleDESCryptography.Encrypt(message, tripleDES.Key, tripleDES.IV);
    File.WriteAllBytes(@"../../../encryptedMessage.txt", data);
    File.WriteAllBytes(@"../../../key.txt", tripleDES.Key);

    string decryptedMessage = TrippleDESCryptography.Decrypt(data, tripleDES.Key, tripleDES.IV);

    Console.WriteLine(decryptedMessage);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

try
{
    string message = "Wolodkin";

    byte[] hash = SHA384.HashData(new ASCIIEncoding().GetBytes(message));

    File.WriteAllBytes(@"../../../hash.txt", hash);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}