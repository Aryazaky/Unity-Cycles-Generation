namespace VfLib
{
	public interface IGraphLoader
	{
		// When nodes/edges are inserted, they are given ID's that they keep through their life.
		// They are entered in a list and the indices in the list may not correspond to the
		// id's.  For instance, if 3 nodes are entered they have id's 0, 1, 2 and their IDs
		// correspond to their indices.  However if node 0 is deleted then we have the nodes
		// 1 and 2 in positions 0 and 1 so their id's don't correspond to their indices.
		//
		// These two types of identifiers are identified as nid for their id and nodeId for their
		// index in a list.  There is a way to swap back and forth for vertex nodes with IdFromPos
		// and PosFromId.  The edges are always identified by nodeId's.
		int NodeCount { get; }
		int IdFromPos(int nodeId);
		object GetNodeAttribute(int nid);
		int OutEdgeCount(int nid);
		int GetOutEdge(int nid, int nodeIdEdge, out object attribute);
		int InEdgeCount(int cEdge);
		int GetInEdge(int nid, int nodeIdEdge, out object attribute);
		int PosFromId(int nid);
	}
}
