using System;
using System.Collections.Generic;

namespace VfLib
{
	[Flags]
	enum Groups
	{
		ContainedInMapping = 1,		// Contained in the mapping
		FromMapping = 2,			// Outside the mapping but pointed to from the mapping
		ToMapping = 4,				// Outside the mapping but points to a node in the mapping
		Disconnected = 8			// Outside the mapping with no links to mapped nodes
	}

	class VfnNode
	{
		#region Private Variables
		VfeNode[] _arvfeEdgeOut;
		VfeNode[] _arvfeEdgeIn;
		object _objAttribute;
		Groups _grps = Groups.Disconnected;
		#endregion

		#region Constructor
		internal VfnNode(IGraphLoader loader, int nodeIdGraph, Dictionary<VfeNode, VfeNode> dctEdge, int[] mpnodeIdGraphnodeIdVf)
		{
			int nid = loader.IdFromPos(nodeIdGraph);
			_objAttribute = loader.GetNodeAttribute(nid);
			_arvfeEdgeOut = new VfeNode[loader.OutEdgeCount(nid)];
			_arvfeEdgeIn = new VfeNode[loader.InEdgeCount(nid)];
			MakeEdges(loader, nid, dctEdge, mpnodeIdGraphnodeIdVf);
		}
		#endregion

		#region Properties

		internal Groups Grps
		{
			get { return _grps; }
			set { _grps = value; }
		}


		internal object Attribute
		{
			get
			{
				return _objAttribute;
			}
		}

		internal int InDegree
		{
			get
			{
				return _arvfeEdgeIn.Length;
			}
		}

		internal int OutDegree
		{
			get
			{
				return _arvfeEdgeOut.Length;
			}
		}

		internal List<int> OutNeighbors
		{
			get
			{
				List<int> lstOut = new List<int>(_arvfeEdgeOut.Length);
				foreach (VfeNode vfe in _arvfeEdgeOut)
				{
					lstOut.Add(vfe._nodeIdTo);
				}
				return lstOut;
			}
		}
		internal List<int> InNeighbors
		{
			get
			{
				List<int> lstIn = new List<int>(_arvfeEdgeIn.Length);
				foreach (VfeNode vfe in _arvfeEdgeIn)
				{
					lstIn.Add(vfe._nodeIdFrom);
				}
				return lstIn;
			}
		}

		internal bool FInMapping
		{
			get { return _grps == Groups.ContainedInMapping; }
		}
		#endregion

		#region Edge Makers
		private void MakeEdges(IGraphLoader loader, int nid, Dictionary<VfeNode, VfeNode> dctEdge, int[] mpnodeIdGraphnodeIdVf)
		{
			int nodeIdGraph = loader.PosFromId(nid);
			int nodeIdVf = mpnodeIdGraphnodeIdVf[nodeIdGraph];
			VfeNode vfeKey = new VfeNode(0, 0, null);

			vfeKey._nodeIdFrom = nodeIdVf;
			MakeOutEdges(loader, nid, dctEdge, mpnodeIdGraphnodeIdVf, ref vfeKey);
			vfeKey._nodeIdTo = nodeIdVf;
			MakeInEdges(loader, nid, dctEdge, mpnodeIdGraphnodeIdVf, ref vfeKey);
		}

		private void MakeOutEdges(IGraphLoader loader, int nid, Dictionary<VfeNode, VfeNode> dctEdge, int[] mpnodeIdGraphnodeIdVf, ref VfeNode vfeKey)
		{
			object attribute;
			for (int i = 0; i < loader.OutEdgeCount(nid); i++)
			{
				vfeKey._nodeIdTo = mpnodeIdGraphnodeIdVf[loader.PosFromId(loader.GetOutEdge(nid, i, out attribute))];

				if (!dctEdge.ContainsKey(vfeKey))
				{
					_arvfeEdgeOut[i] = dctEdge[vfeKey] = new VfeNode(vfeKey._nodeIdFrom, vfeKey._nodeIdTo, attribute);
					vfeKey = new VfeNode(vfeKey._nodeIdFrom, vfeKey._nodeIdTo, null);
				}
				else
				{
					_arvfeEdgeOut[i] = dctEdge[vfeKey];
				}
			}
		}

		private void MakeInEdges(IGraphLoader loader, int nid, Dictionary<VfeNode, VfeNode> dctEdge, int[] mpnodeIdGraphnodeIdVf, ref VfeNode vfeKey)
		{
			object attribute;
			for (int i = 0; i < loader.InEdgeCount(nid); i++)
			{
				vfeKey._nodeIdFrom = mpnodeIdGraphnodeIdVf[loader.PosFromId(loader.GetInEdge(nid, i, out attribute))];

				if (!dctEdge.ContainsKey(vfeKey))
				{
					_arvfeEdgeIn[i] = dctEdge[vfeKey] = new VfeNode(vfeKey._nodeIdFrom, vfeKey._nodeIdTo, attribute);
					vfeKey = new VfeNode(vfeKey._nodeIdFrom, vfeKey._nodeIdTo, null);
				}
				else
				{
					_arvfeEdgeIn[i] = dctEdge[vfeKey];
				}
			}
		}
		#endregion
	}
}
