using UnityEngine;
using TMPro;
using System.Collections.Generic;

namespace VirtualKeyboard
{
    class ReceiveInputField : MonoBehaviour
    {
        TMP_InputField inputText;
        bool isSubscribed = false;

        Dictionary<string, string> greekToEnglishDict = new Dictionary<string, string>()
    {
        {"διαγραφή", "backspace"},
        {"διαγραφή όλων","clear all"},
        {"κεφαλαία", "caps lock"},
        {"τόνοι", "shift"}
    };

        public bool IsSubscribed { get => isSubscribed; }

        private void Start()
        {
            inputText = GetComponent<TMP_InputField>();
        }

        public void Subscribe()
        {
            print("subbed");
            isSubscribed = true;
            KeyPressEventSender.onKeyPress += Receive;
        }

        public void Unsubscribe()
        {
            print("unsubbed");
            isSubscribed = false;
            KeyPressEventSender.onKeyPress -= Receive;
        }

        public void Receive(string value)
        {
            string newValue;
            //check if it exists in the dictionary
            if (!greekToEnglishDict.TryGetValue(value.ToLower(), out newValue))
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
            inputText.text += letter;
        }

        private void DeleteLetter()
        {
            var text = inputText.text;
            if (text.Length <= 0) return;

            inputText.text = text.Remove(text.Length - 1, 1);
        }

        private void AddSpace()
        {
            inputText.text += " ";
        }

        public void DeleteEverything()
        {
            inputText.text = "";
        }
    }
}
