using System.Security.Cryptography;
using System.Text;

namespace lb_2;

public static class SRP
{
    private static RSA rsa;

    static SRP()
    {
        rsa = RSA.Create();
        rsa.KeySize = 2048;
    }


    public static List<string> GenerateSRP()
    {
        var faker = new Bogus.Faker();
        List<string> srp = new List<string>();

        while (srp.Count < 12)
        {
            string word = faker.Random.Word();

            if (!string.IsNullOrWhiteSpace(word) && !srp.Contains(word) && !word.Contains(" "))
            {
                srp.Add(word);
            }
        }

        return srp;
    }

    public static byte[] Encrypt(string data)
    {
        byte[] dataToEncrypt = Encoding.UTF8.GetBytes(data);
        return rsa.Encrypt(dataToEncrypt, RSAEncryptionPadding.OaepSHA256);
    }

    public static string Decrypt(byte[] data)
    {
        byte[] decryptedData = rsa.Decrypt(data, RSAEncryptionPadding.OaepSHA256);
        return Encoding.UTF8.GetString(decryptedData);
    }

    public static string ComputeHash(string data)
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(data));
            return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
        }
    }
}