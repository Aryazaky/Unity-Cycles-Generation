namespace Core
{
    public interface INodeEdge
    {
        INode NodeA { get; }
        INode NodeB { get; }
        INode GetOtherNode(INode node);
    }
}