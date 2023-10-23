namespace Core
{
    public class Edge : INodeEdge
    {
        public Edge(INode from, INode to)
        {
            From = from;
            To = to;
        }

        public INode From { get; }
        public INode To { get; }
    }
}