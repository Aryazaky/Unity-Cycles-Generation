using UnityEngine;

namespace Core.Nodes
{
    public class PositionNode : Node<string>
    {
        private readonly Vector3 position;

        public PositionNode(Vector3 position) : base("HasPosition")
        {
            this.position = position;
        }
    }
}
