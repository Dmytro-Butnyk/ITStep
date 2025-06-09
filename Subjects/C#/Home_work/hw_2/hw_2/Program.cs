class KruskalAlgorithm
{
    class Edge
    {
        public int Source { get; set; }
        public int Destination { get; set; }
        public int Weight { get; set; }
    }

    class Subset
    {
        public int Parent { get; set; }
        public int Rank { get; set; }
    }

    private int vertices;
    private List<Edge> edges;

    public KruskalAlgorithm(int vertices)
    {
        this.vertices = vertices;
        this.edges = new List<Edge>();
    }

    public void AddEdge(int source, int destination, int weight)
    {
        edges.Add(new Edge { Source = source, Destination = destination, Weight = weight });
    }

    private int Find(Subset[] subsets, int i)
    {
        if (subsets[i].Parent != i)
            subsets[i].Parent = Find(subsets, subsets[i].Parent);

        return subsets[i].Parent;
    }

    private void Union(Subset[] subsets, int x, int y)
    {
        int xRoot = Find(subsets, x);
        int yRoot = Find(subsets, y);

        if (subsets[xRoot].Rank < subsets[yRoot].Rank)
            subsets[xRoot].Parent = yRoot;
        else if (subsets[xRoot].Rank > subsets[yRoot].Rank)
            subsets[yRoot].Parent = xRoot;
        else
        {
            subsets[yRoot].Parent = xRoot;
            subsets[xRoot].Rank++;
        }
    }

    public void KruskalMST()
    {
        List<Edge> result = new List<Edge>();
        int edgeIndex = 0;

        edges = edges.OrderBy(edge => edge.Weight).ToList();

        Subset[] subsets = new Subset[vertices];
        for (int i = 0; i < vertices; i++)
        {
            subsets[i] = new Subset { Parent = i, Rank = 0 };
        }

        while (result.Count < vertices - 1)
        {
            Edge nextEdge = edges[edgeIndex++];

            int x = Find(subsets, nextEdge.Source);
            int y = Find(subsets, nextEdge.Destination);

            if (x != y)
            {
                result.Add(nextEdge);
                Union(subsets, x, y);
            }
        }

        Console.WriteLine("Minimum Spanning Tree (Kruskal's Algorithm):");
        foreach (Edge edge in result)
        {
            Console.WriteLine($"{edge.Source} - {edge.Destination} : {edge.Weight}");
        }
    }
}

class Program
{
    static void Main()
    {
        KruskalAlgorithm graph = new KruskalAlgorithm(4);

        graph.AddEdge(0, 1, 10);
        graph.AddEdge(0, 2, 6);
        graph.AddEdge(0, 3, 5);
        graph.AddEdge(1, 3, 15);
        graph.AddEdge(2, 3, 4);

        graph.KruskalMST();
    }
}