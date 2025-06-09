namespace lb_3.Models;

public class WalletManager
{
    private Dictionary<string, CryptoWallet> wallets = new Dictionary<string, CryptoWallet>();

    public CryptoWallet CreateWallet(string userLogin, decimal initialBalance)
    {
        var wallet = new CryptoWallet(userLogin, initialBalance);
        wallets[wallet.PrivateKey] = wallet;
        return wallet;
    }

    public CryptoWallet RecoverWallet(string secretPhrase)
    {
        return wallets.Values.FirstOrDefault(w => w.SecretRecoveryPhrase == secretPhrase);
    }

    public void PrintWalletInfo(CryptoWallet wallet)
    {
        if (wallet != null)
        {
            Console.WriteLine($"User: {wallet.UserLogin}");
            Console.WriteLine($"Private Key: {wallet.PrivateKey}");
            Console.WriteLine($"Secret Recovery Phrase: {wallet.SecretRecoveryPhrase}");
            Console.WriteLine($"Balance: {wallet.Balance} BTC\n");
        }
        else
        {
            Console.WriteLine("Wallet not found.\n");
        }
    }
}