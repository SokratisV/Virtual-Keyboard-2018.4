using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Virtual_Keyboard.Scripts.Core;

namespace Virtual_Keyboard.Scripts.Misc
{
    public class ReceiveInput : MonoBehaviour
    {
        TextMeshProUGUI _textComponent;
        readonly Dictionary<string, string> _greekToEnglishDict = new Dictionary<string, string>()
    {
        {"διαγραφή", "backspace"},
        {"διαγραφή όλων","clear all"},
        {"κεφαλαία", "caps lock"},
        {"τόνοι", "shift"}
    };

        private void OnEnable()
        {
            KeyPressEventSender.OnKeyPress += Receive;
        }

        private void OnDisable()
        {
            KeyPressEventSender.OnKeyPress -= Receive;
        }

        private void Start()
        {
            _textComponent = GetComponentInChildren<TextMeshProUGUI>();
        }

        private void Receive(string value)
        {
            //check if it exists in the dictionary
            if (!_greekToEnglishDict.TryGetValue(value.ToLower(), out var newValue))
            {
                newValue = value;
            }
            switch (newValue.ToLower())
            {
                case "backspace":
                    DeleteLetter();
                    break;
                case " ":
                    AddSpace();
                    break;
                case "clear all":
                    DeleteEverything();
                    break;
                case "enter":
                    break;
                case "caps lock":
                    break;
                case "shift":
                    break;
                default:
                    PrintLetter(value);
                    break;
            }
        }

        private void PrintLetter(string letter)
        {
            _textComponent.text += letter;
        }

        private void DeleteLetter()
        {
            var text = _textComponent.text;
            if (text.Length <= 0) return;

            _textComponent.text = text.Remove(text.Length - 1, 1);
        }

        private void AddSpace()
        {
            _textComponent.text += " ";
        }

        public void DeleteEverything()
        {
            _textComponent.text = "";
        }
    }
}
