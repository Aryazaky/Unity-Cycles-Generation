namespace Core.Edges
{
    public class WeightedEdge : Edge
    {
        private readonly int weight;

        public WeightedEdge(INode a, INode b, int weight) : base(a, b)
        {
            this.weight = weight;
        }
    }
}