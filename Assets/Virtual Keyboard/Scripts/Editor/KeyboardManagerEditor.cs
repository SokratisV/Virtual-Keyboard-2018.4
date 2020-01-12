using UnityEditor;
using UnityEngine;

namespace VirtualKeyboard
{
    [CustomEditor(typeof(KeyboardManager))]
    public class KeyboardManagerEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            KeyboardManager manager = (KeyboardManager)target;

            if (GUILayout.Button("Refresh Keyboard"))
            {
                manager.RefreshKeyboard();
            }
        }
    }
}