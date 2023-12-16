using System;
using Core;
using Core.Edges;
using Core.Nodes;
using UnityEngine;
using VfLib;

namespace Tests
{
    public class NodeTest : MonoBehaviour
    {
        private void Start()
        {
            Node<string> a = new Node<string>("A", "First Ever Node");
            Node<string> b = new Node<string>("B", "Second Node");
            Node<string> c = new Node<string>("C");
            Node<string> a2 = new Node<string>("A", "First Ever Node", "The V2");
            Node<string> b2 = new Node<string>("B", "Second Node", "The V2");
            Node<string> c2 = new Node<string>("C", "The V2");
            Node<string> nodeWithNoTag = new Node<string>();

            // equality test (expected true)
            Debug.Log($"A != B: {!Equals(a, b)}");
            Debug.Log($"C == C2: {Equals(c, c2)}");
            Debug.Log($"A2 != NodeWithNoTag: {!Equals(a2, nodeWithNoTag)}");
            
            // connecting with edges
            Edge ab = new WeightedEdge(a, b, 2);
            Edge bc = new Edge(b, c);
            Edge ac = new Edge(a, c);
            a.AddNeighbor(ab);
            a.AddNeighbor(ac);
            b.AddNeighbor(ab);
            b.AddNeighbor(bc);
            c.AddNeighbor(ac);
            c.AddNeighbor(bc);
            
            // Do the same thing for a2, b2, c2
            Edge a2b2 = new Edge(a2, b2);
            Edge b2c2 = new Edge(b2, c2);
            Edge a2c2 = new Edge(a2, c2);
            a2.AddNeighbor(a2b2);
            a2.AddNeighbor(a2c2);
            b2.AddNeighbor(a2b2);
            b2.AddNeighbor(b2c2);
            c2.AddNeighbor(a2c2);
            c2.AddNeighbor(b2c2);

            Graph<Node<string>> graph = new Graph<Node<string>>(new []{ a, b, c });

            // equality test again (expected true)
            Debug.Log($"A != B: {!Equals(a, b)}");
            Debug.Log($"C == C2: {Equals(c, c2)}");
            Debug.Log($"A2 != NodeWithNoTag: {!Equals(a2, nodeWithNoTag)}");

            // Test adding the same edge twice (expected: error)
            try
            {
                a.AddNeighbor(ab);
            }
            catch (Exception e)
            {
                Debug.LogError($"Error adding the same edge twice: {e.Message}");
            }

            // Test adding a different edge but has the same nodes
            // (expected: old one is replaced. check with e.g. a.Edges.Where(contains these nodes))
            Edge newAc = new Edge(a, c);
            a.AddNeighbor(newAc);
            
            // other tests
            VfLib.Graph graphVf = new();
            VfLib.FullMapping fullMapping = new FullMapping();
            
            // coba VFLib di visual studio
        }
    }
}