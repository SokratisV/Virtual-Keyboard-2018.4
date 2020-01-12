using UnityEngine;

namespace VirtualKeyboard
{
    [CreateAssetMenu(fileName = "ButtonRowNames", menuName = "Virtual Keyboard/ButtonRowNames", order = 0)]
    public class ButtonRowNames : ScriptableObject
    {
        public string[] buttonNames;

        private void Start()
        {
            if (buttonNames == null || buttonNames.Length == 0)
            {
                Debug.Log("Rows have no button names assigned");
            }
        }
    }
}


