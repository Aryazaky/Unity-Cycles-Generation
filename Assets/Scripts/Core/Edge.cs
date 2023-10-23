namespace CyclesGen.Core
{
    public class Edge : INodeEdge
    {
        public Edge(Node from, Node to)
        {
            From = from;
            To = to;
        }

        public Node From { get; }
        public Node To { get; }
    }
}