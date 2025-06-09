using System.Security.Cryptography;
using System.Text;

namespace lb_2.models;

public class Block
{
    public int Index { get; private set; }
    public DateTime Timestamp { get; private set; }
    public string Data { get; private set; }
    public string Hash { get; set; }
    public string PreviousHash { get; set; }

    public Block(DateTime timestamp, string previousHash, string data)
    {
        Index = Blockchain.BlocksCount++;
        Timestamp = timestamp;
        PreviousHash = previousHash ?? "0";
        Data = data;
        Hash = CalculateHash();
    }

    public string CalculateHash()
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            var rawData = $"{Timestamp}-{PreviousHash ?? ""}-{Data}";
            byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(rawData));
            return BitConverter.ToString(bytes).Replace("-", "").ToLower();
        }
    }
}