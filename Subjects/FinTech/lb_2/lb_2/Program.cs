using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Bogus;
using lb_2.models;

namespace lb_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("SRP generator and encryptor:");
            List<string> srp = SRP.GenerateSRP();

            Console.WriteLine("Secret Recovery Phrase:");
            srp.ForEach(word => Console.WriteLine(word));

            string srpJoined = string.Join(" ", srp);
            var encryptedSRP = SRP.Encrypt(srpJoined);
            Console.WriteLine($"\nEncrypted SRP: {Convert.ToBase64String(encryptedSRP)}");

            var decryptedSRP = SRP.Decrypt(encryptedSRP);
            Console.WriteLine($"\nDecrypted SRP: {decryptedSRP}");

            var hash = SRP.ComputeHash(srpJoined);
            Console.WriteLine($"\nHash of SRP: {hash}");

            Console.WriteLine("\n**Blockchain:**");

            Blockchain blockchain = new Blockchain();
            blockchain.AddBlock(new Block(DateTime.Now, null, "Олексій Тестін 2314"));
            blockchain.AddBlock(new Block(DateTime.Now, null, "Марія Іванова 4321"));
            blockchain.AddBlock(new Block(DateTime.Now, null, "Андрій Сидоров 5678"));

            foreach (var block in blockchain.Chain)
            {
                Console.WriteLine(
                    $"Index: {block.Index}, Timestamp: {block.Timestamp}, Data: {block.Data}, Hash: {block.Hash}, PreviousHash: {block.PreviousHash}");
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}