namespace Core
{
    /// <summary>
    /// Represents an edge
    /// </summary>
    public interface INodeEdge
    {
        INode NodeA { get; }
        INode NodeB { get; }
        INode GetOtherNode(INode node);
    }
}