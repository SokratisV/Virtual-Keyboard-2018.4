using UnityEngine;

namespace Virtual_Keyboard.Scripts.Core.Languages
{
    [CreateAssetMenu(fileName = "New Language Row", menuName = "Virtual Keyboard/Keyboard Language Row", order = 0)]
    public class ButtonRowNames : ScriptableObject
    {
        public string[] buttonNames;
    }
}


