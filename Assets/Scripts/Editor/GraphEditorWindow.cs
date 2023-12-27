using Core;
using Scriptables;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    public class GraphEditorWindow : EditorWindow
    {
        private GraphScriptableBase graphScriptable;

        [MenuItem("Window/CyclesGen/Graph Editor")]
        public static GraphEditorWindow OpenGraphEditorWindow()
        {
            return EditorWindow.GetWindow<GraphEditorWindow>("Graph Editor Window");
        }

        [UnityEditor.Callbacks.OnOpenAsset(1)]
        public static bool OnOpenGraph(int instanceID, int line)
        {
            var file = EditorUtility.InstanceIDToObject(instanceID) as GraphScriptableBase;
            if (file != null)
            {
                var window = OpenGraphEditorWindow();
                window.graphScriptable = file;
                return true;
            }

            return false;
        }

        private void OnGUI()
        {
            if (graphScriptable != null)
            {
                int i = 0;
                foreach (var scriptableEdge in graphScriptable.Edges)
                {
                    GUI.Label(new Rect(10, 10 + i, 1000, 20),
                        $"{scriptableEdge.name} is connecting {scriptableEdge.NodeA.name} to {scriptableEdge.NodeB.name}");
                    i += 20;
                }
            }
        }
    }
}