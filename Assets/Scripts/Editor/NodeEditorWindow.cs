using UnityEditor;
using UnityEngine;

namespace Editor
{
    public class NodeEditorWindow : EditorWindow
    {
        [MenuItem("Window/CyclesGen/Node Editor")]
        private static void ShowWindow()
        {
            var window = GetWindow<NodeEditorWindow>();
            window.titleContent = new GUIContent("Node Editor Window");
            window.Show();
        }

        private void OnGUI()
        {
            
        }
    }
}