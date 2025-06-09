using lb_3.Models;

WalletManager manager = new WalletManager();

var wallet1 = manager.CreateWallet("user1", 2.5m);
var wallet2 = manager.CreateWallet("user2", 5.0m);
var wallet3 = manager.CreateWallet("user3", 1.2m);

manager.PrintWalletInfo(wallet1);
manager.PrintWalletInfo(wallet2);
manager.PrintWalletInfo(wallet3);

Console.WriteLine("Recovering wallet...");
CryptoWallet recoveredWallet = manager.RecoverWallet(wallet2.SecretRecoveryPhrase);
manager.PrintWalletInfo(recoveredWallet);