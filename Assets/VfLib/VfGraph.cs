using System;
using System.Collections.Generic;
#if NUNIT
using NUnit.Framework;
#endif

namespace VfLib
{
	class VfGraph
	{
		#region Private Variables
		VfnNode[] _arNodes;
		#endregion

		#region Properties
		internal int NodeCount
		{
			get
			{
				return _arNodes.Length;
			}
		}
		#endregion

		#region Accessors
		internal int OutDegree(int nodeId)
		{
			return _arNodes[nodeId].OutDegree;
		}

		internal int InDegree(int nodeId)
		{
			return _arNodes[nodeId].InDegree;
		}

		internal int TotalDegree(int nodeId)
		{
			return OutDegree(nodeId) + InDegree(nodeId);
		}

		internal List<int> OutNeighbors(int nodeId)
		{
			return _arNodes[nodeId].OutNeighbors;
		}

		internal List<int> InNeighbors(int nodeId)
		{
			return _arNodes[nodeId].InNeighbors;
		}

		internal Groups GetGroup(int nodeId)
		{
			return _arNodes[nodeId].Grps;
		}

		internal void SetGroup(int nodeId, Groups grps)
		{
			_arNodes[nodeId].Grps = grps;
		}

		internal object GetAttribute(int nodeId)
		{
			return _arNodes[nodeId].Attribute;
		}
		#endregion

		#region Constructor
		internal static int[] ReversePermutation(int[] perm)
		{
			int[] permOut = new int[perm.Length];
			for (int i = 0; i < perm.Length; i++)
			{
				permOut[i] = Array.IndexOf<int>(perm, i);
			}
			return permOut;
		}

		internal VfGraph(IGraphLoader loader, int[] mpnodeIdVfnodeIdGraph)
		{
			_arNodes = new VfnNode[loader.NodeCount];
			int[] mpnodeIdGraphnodeIdVf = ReversePermutation(mpnodeIdVfnodeIdGraph);
			Dictionary<VfeNode, VfeNode> dctEdge = new Dictionary<VfeNode, VfeNode>();

			for (int nodeIdVf = 0; nodeIdVf < loader.NodeCount; nodeIdVf++)
			{
				_arNodes[nodeIdVf] = new VfnNode(loader, mpnodeIdVfnodeIdGraph[nodeIdVf], dctEdge, mpnodeIdGraphnodeIdVf);
			}
		}
		#endregion

		#region NUNIT Testing
#if NUNIT
		[TestFixture]
		public class VfGraphTester
		{
			VfGraph SetupGraph()
			{
				Graph graph = new Graph();
				Assert.AreEqual(0, graph.InsertNode());
				Assert.AreEqual(1, graph.InsertNode());
				Assert.AreEqual(2, graph.InsertNode());
				Assert.AreEqual(3, graph.InsertNode());
				Assert.AreEqual(4, graph.InsertNode());
				Assert.AreEqual(5, graph.InsertNode());
				graph.InsertEdge(0, 1);
				graph.InsertEdge(1, 2);
				graph.InsertEdge(2, 3);
				graph.InsertEdge(3, 4);
				graph.InsertEdge(4, 5);
				graph.InsertEdge(5, 0);
				graph.DeleteNode(0);
				graph.DeleteNode(1);
				graph.InsertEdge(5, 2);
				graph.InsertEdge(2, 4);

				return new VfGraph(graph, (new CmpNodeDegrees(graph)).Permutation);
			}

			[Test]
			public void TestPermutations()
			{
				Graph graph = new Graph();
				Assert.AreEqual(0, graph.InsertNode());
				Assert.AreEqual(1, graph.InsertNode());
				Assert.AreEqual(2, graph.InsertNode());
				graph.InsertEdge(1, 0);
				graph.InsertEdge(1, 2);
				int[] mpPermutation = (new CmpNodeDegrees(graph)).Permutation;
				VfGraph vfg = new VfGraph(graph, mpPermutation);
				Assert.AreEqual(mpPermutation[1], 0);
				int[] arOut = new int[vfg._arNodes[0].OutNeighbors.Count];
				vfg._arNodes[0].OutNeighbors.CopyTo(arOut, 0);
				int nodeIdNeighbor1 = arOut[0];
				int nodeIdNeighbor2 = arOut[1];
				Assert.IsTrue(nodeIdNeighbor1 == 1 && nodeIdNeighbor2 == 2 || nodeIdNeighbor1 == 2 && nodeIdNeighbor2 == 1);
			}

			[Test]
			public void TestConstructor()
			{
				Assert.IsNotNull(SetupGraph());
			}

			[Test]
			public void TestNodeCount()
			{
				Assert.AreEqual(4, SetupGraph().NodeCount);
			}
		}
#endif
		#endregion
	}
}
