namespace Core
{
    public interface INodeEdge
    {
        INode From { get; }
        INode To { get; }
    }
}