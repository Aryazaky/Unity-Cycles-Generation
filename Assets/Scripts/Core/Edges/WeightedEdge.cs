namespace Core.Edges
{
    public class WeightedEdge : INodeEdge
    {
        private readonly int weight;

        public WeightedEdge(INode from, INode to, int weight)
        {
            this.weight = weight;
            From = from;
            To = to;
        }

        public INode From { get; }
        public INode To { get; }
    }
}