using UnityEditor;
using UnityEngine;
using Virtual_Keyboard.Scripts.Visuals;

namespace Virtual_Keyboard.Scripts.Editor
{
    [CustomEditor(typeof(KeyboardThemeManager))]
    public class KeyboardThemeEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            var manager = (KeyboardThemeManager)target;

            if (GUILayout.Button("Apply Theme"))
            {
                manager.ChangeToCurrentTheme();
            }
        }
    }
}
