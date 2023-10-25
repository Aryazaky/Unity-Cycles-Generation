namespace Core.Edges
{
    public class Edge : INodeEdge
    {
        public Edge(INode a, INode b)
        {
            NodeA = a;
            NodeB = b;
        }

        public INode NodeA { get; }
        public INode NodeB { get; }
        public INode GetOtherNode(INode node)
        {
            return node == NodeA 
                ? NodeB 
                : node == NodeB 
                    ? NodeA 
                    : null;
        }
    }
}