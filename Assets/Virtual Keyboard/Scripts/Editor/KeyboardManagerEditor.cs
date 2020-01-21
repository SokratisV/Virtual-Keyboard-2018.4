using UnityEditor;
using UnityEngine;
using Virtual_Keyboard.Scripts.Core;

namespace Virtual_Keyboard.Scripts.Editor
{
    [CustomEditor(typeof(KeyboardManager))]
    public class KeyboardManagerEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            var manager = (KeyboardManager)target;

            if (GUILayout.Button("Refresh Keyboard"))
            {
                manager.RefreshKeyboard();
            }
        }
    }
}