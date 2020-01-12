using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace VirtualKeyboard
{
    public class PhysicalKeyboardInput : MonoBehaviour
    {
        [SerializeField]
        Button backspaceButton = null,
            spaceButton = null,
            capsLockButton = null,
            clearAllButton = null,
            enterButton = null,
            shiftButton = null;
        string availableCharacters = "qwertyuiopasdfghjklzxcvbnm1234567890;ςερτυθιοπασδφγηξκλζχψωβνμ";
        Dictionary<string, string> specialCharacterDictionary = new Dictionary<string, string>(){
        {"έ", "ε"},
        {"ά", "α"},
        {"ό", "ο"},
        {"ώ", "ω"},
        {"ή", "η"},
        {"ί", "ι"},
        {"ύ", "υ"}
    };

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                shiftButton?.onClick.Invoke();
            }
            if (Input.GetKeyDown(KeyCode.CapsLock))
            {
                capsLockButton?.onClick.Invoke();
            }
            if (Input.GetKeyDown(KeyCode.Backspace))
            {
                backspaceButton?.onClick.Invoke();
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                spaceButton?.onClick.Invoke();
            }
            if (Input.GetKeyDown(KeyCode.Delete))
            {
                clearAllButton?.onClick.Invoke();
            }
            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                enterButton?.onClick.Invoke();
            }
            foreach (char c in Input.inputString)
            {
                string value = c.ToString().ToLower();
                if (availableCharacters.Contains(value))
                {
                    foreach (TextMeshProUGUI textMeshButton in GetComponentsInChildren<TextMeshProUGUI>())
                    {
                        string buttonText = textMeshButton.text.ToLower();
                        if (buttonText.Equals(value) ||
                            specialCharacterDictionary.TryGetValue(buttonText, out var strippedCharacter) && strippedCharacter.Equals(value))
                        {
                            textMeshButton.GetComponentInParent<Button>().onClick.Invoke();
                        }
                    }
                }
            }
        }
    }

}
