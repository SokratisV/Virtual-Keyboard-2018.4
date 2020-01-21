using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Virtual_Keyboard.Scripts.Misc
{
    public class PhysicalKeyboardInput : MonoBehaviour
    {
        [SerializeField] Button
            backspaceButton = null,
            spaceButton = null,
            capsLockButton = null,
            clearAllButton = null,
            enterButton = null,
            shiftButton = null;

        private const string AvailableCharacters =
            @"qwertyuiopasdfghjklzxcvbnm1234567890;ςερτυθιοπασδφγηξκλζχψωβνμ!@#$%^&*()_+-={}|[]:,./<>?";
        readonly Dictionary<string, string> _specialCharacterDictionary = new Dictionary<string, string>(){
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
                shiftButton.onClick?.Invoke();
            }
            if (Input.GetKeyDown(KeyCode.CapsLock))
            {
                capsLockButton.onClick?.Invoke();
            }
            if (Input.GetKeyDown(KeyCode.Backspace))
            {
                backspaceButton.onClick?.Invoke();
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                spaceButton.onClick?.Invoke();
            }
            if (Input.GetKeyDown(KeyCode.Delete))
            {
                clearAllButton.onClick?.Invoke();
            }
            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                enterButton.onClick?.Invoke();
            }

            var textMeshProUGUIs = GetComponentsInChildren<TextMeshProUGUI>();
            foreach (var c in Input.inputString)
            {
                var value = c.ToString().ToLower();
                if (!AvailableCharacters.Contains(value)) continue;
                
                foreach (var textMeshButton in textMeshProUGUIs)
                {
                    var buttonText = textMeshButton.text.ToLower();
                    if (buttonText.Equals(value) ||
                        _specialCharacterDictionary.TryGetValue(buttonText, out var strippedCharacter) && strippedCharacter.Equals(value))
                    {
                        textMeshButton.GetComponentInParent<Button>().onClick.Invoke();
                        break;
                    }
                }
            }
        }
    }

}
