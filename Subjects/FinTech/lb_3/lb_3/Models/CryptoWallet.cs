using System.Security.Cryptography;

namespace lb_3.Models;

public class CryptoWallet
{
    public string PrivateKey { get; private set; }
    public string SecretRecoveryPhrase { get; private set; }
    public string UserLogin { get; private set; }
    public decimal Balance { get; private set; }

    public CryptoWallet(string userLogin, decimal initialBalance)
    {
        PrivateKey = GeneratePrivateKey();
        SecretRecoveryPhrase = GenerateSecretPhrase();
        UserLogin = userLogin;
        Balance = initialBalance;
    }

    private static string GeneratePrivateKey()
    {
        using (var rng = new RNGCryptoServiceProvider())
        {
            byte[] privateKeyBytes = new byte[32];
            rng.GetBytes(privateKeyBytes);
            return BitConverter.ToString(privateKeyBytes).Replace("-", "").ToLower();
        }
    }

    private static string GenerateSecretPhrase()
    {
        string[] words = {
            "apple", "banana", "cherry", "dragon", "elephant", "forest", "giraffe",
            "honey", "island", "jungle", "koala", "lemon", "mountain", "nectar",
            "ocean", "piano", "quartz", "river", "sunset", "tiger", "umbrella",
            "violet", "whale", "xenon", "yellow", "zebra"
        };

        Random random = new Random();
        return string.Join(" ", Enumerable.Range(0, 12).Select(_ => words[random.Next(words.Length)]));
    }
}