using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Virtual_Keyboard.Scripts.Core;

namespace Virtual_Keyboard.Scripts.Misc
{
    class ReceiveInputField : MonoBehaviour
    {
        TMP_InputField _inputText;
        bool _isSubscribed = false;

        readonly Dictionary<string, string> _greekToEnglishDict = new Dictionary<string, string>()
    {
        {"διαγραφή", "backspace"},
        {"διαγραφή όλων","clear all"},
        {"κεφαλαία", "caps lock"},
        {"τόνοι", "shift"}
    };

        public bool IsSubscribed { get => _isSubscribed; }

        private void Start()
        {
            _inputText = GetComponent<TMP_InputField>();
        }

        public void Subscribe()
        {
            _isSubscribed = true;
            KeyPressEventSender.OnKeyPress += Receive;
        }

        public void Unsubscribe()
        {
            _isSubscribed = false;
            KeyPressEventSender.OnKeyPress -= Receive;
        }

        public void Receive(string value)
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
            _inputText.text += letter;
        }

        private void DeleteLetter()
        {
            var text = _inputText.text;
            if (text.Length <= 0) return;

            _inputText.text = text.Remove(text.Length - 1, 1);
        }

        private void AddSpace()
        {
            _inputText.text += " ";
        }

        public void DeleteEverything()
        {
            _inputText.text = "";
        }
    }
}
