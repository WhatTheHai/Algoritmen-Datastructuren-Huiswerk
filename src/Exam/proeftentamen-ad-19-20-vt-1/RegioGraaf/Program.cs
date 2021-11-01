namespace AD
{
    class Program
    {
        static void Main(string[] args)
        {
            IGraph graph14_1 = DSBuilder.CreateGraphFromBook14_1();
            IGraph graph;

            System.Console.WriteLine(graph14_1);
            graph14_1.Dijkstra("V0");
            System.Console.WriteLine(graph14_1);

            graph = new Graph();
            graph.AddVertex("A", "Q");
            graph.AddVertex("B", "R");
            graph.AddVertex("C", "R");
            graph.AddVertex("D", "R");
            graph.AddVertex("E", "R");
            graph.AddVertex("F", "S");
            graph.AddVertex("G", "R");

            graph.AddUndirectedEdge("A", "B", 2);
            graph.AddUndirectedEdge("A", "C", 3);
            graph.AddUndirectedEdge("A", "G", 4);

            graph.AddUndirectedEdge("B", "C", 8);
            graph.AddUndirectedEdge("B", "D", 10);
            graph.AddUndirectedEdge("B", "F", 3);

            graph.AddUndirectedEdge("C", "E", 5);

            graph.AddUndirectedEdge("D", "E", 2);
            graph.AddUndirectedEdge("D", "F", 4);

            System.Console.WriteLine(graph);
            graph.RegioDijkstra("A");
            System.Console.WriteLine(graph);
            System.Console.WriteLine(graph.AllPaths());
        }
    }
}
