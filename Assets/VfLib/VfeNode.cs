using System;

namespace VfLib
{
	class VfeNode : IEquatable<VfeNode>
	{
		#region Private Variables
		internal int _nodeIdFrom;
		internal int _nodeIdTo;
		internal object _objAttribute;
		#endregion

		#region Constructor
		internal VfeNode(int nodeIdFrom, int nodeIdTo, object objAttribute)
		{
			_nodeIdFrom = nodeIdFrom;
			_nodeIdTo = nodeIdTo;
			_objAttribute = objAttribute;
		}
		#endregion

		#region Hashing
		public override int GetHashCode()
		{
			int iTest = _nodeIdTo.GetHashCode();
			return ((_nodeIdFrom << 16) + _nodeIdTo).GetHashCode();
		}

		public bool Equals(VfeNode other)
		{
			return (other != null) && (other._nodeIdFrom.Equals(_nodeIdFrom) && other._nodeIdTo.Equals(_nodeIdTo));
		}
		#endregion
	}
}
