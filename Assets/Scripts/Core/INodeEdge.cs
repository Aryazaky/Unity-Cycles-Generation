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
        bool Contains(INode node);
    }
    
    /// <summary>
    /// Represents an edge
    /// </summary>
    public interface INodeEdge<T> where T : INode
    {
        T NodeA { get; }
        T NodeB { get; }
        T GetOtherNode(T node);
        bool Contains(T node);
    }
}