using UnityEditor;
using UnityEngine;

namespace VirtualKeyboard
{
    [CustomEditor(typeof(KeyboardThemeManager))]
    public class KeyboardThemeEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            KeyboardThemeManager manager = (KeyboardThemeManager)target;

            if (GUILayout.Button("Apply Theme"))
            {
                manager.ChangeToCurrentTheme();
            }
        }
    }
}
