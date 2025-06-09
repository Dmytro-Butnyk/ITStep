namespace lb_2.models;

public class Blockchain
{
    public static int BlocksCount = 0;
    public List<Block> Chain { get; private set; }

    public Blockchain()
    {
        Chain = new List<Block>();
    }

    public void AddBlock(Block block)
    {
        if (Chain.Count > 0)
        {
            block.PreviousHash = Chain[Chain.Count - 1].Hash;
        }

        block.Hash = block.CalculateHash();
        Chain.Add(block);
    }
}