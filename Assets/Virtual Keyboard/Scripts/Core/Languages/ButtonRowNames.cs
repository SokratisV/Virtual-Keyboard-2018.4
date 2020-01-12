using UnityEngine;

namespace VirtualKeyboard
{
    [CreateAssetMenu(fileName = "New Language Row", menuName = "Virtual Keyboard/Keyboard Language Row", order = 0)]
    public class ButtonRowNames : ScriptableObject
    {
        public string[] buttonNames;
    }
}


