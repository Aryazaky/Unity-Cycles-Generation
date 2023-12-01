namespace VfLib
{
	class Match
	{
		#region Private Variables
		int _nodeId1;
		int _nodeId2;
		#endregion

		#region Properties
		internal int nodeId1
		{
			get { return _nodeId1; }
			set { _nodeId1 = value; }
		}

		internal int nodeId2
		{
			get { return _nodeId2; }
		}
		#endregion

		#region Constructor
		public Match(int nodeId1, int nodeId2)
		{
			_nodeId1 = nodeId1;
			_nodeId2 = nodeId2;
		}
		#endregion
	}
}
