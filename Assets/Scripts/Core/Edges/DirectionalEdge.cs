namespace Core.Edges
{
    public class DirectionalEdge : INodeEdge
    {
        public DirectionalEdge(INode from, INode to)
        {
            From = from;
            To = to;
        }

        public INode From { get; }
        public INode To { get; }
    }
}