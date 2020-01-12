using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace VirtualKeyboard
{
    public class ReceiveInput : MonoBehaviour
    {
        TextMeshProUGUI textComponent;
        Dictionary<string, string> greekToEnglishDict = new Dictionary<string, string>()
    {
        {"διαγραφή", "backspace"},
        {"διαγραφή όλων","clear all"},
        {"κεφαλαία", "caps lock"},
        {"τόνοι", "shift"}
    };

        private void OnEnable()
        {
            KeyPressEventSender.onKeyPress += Receive;
        }

        private void OnDisable()
        {
            KeyPressEventSender.onKeyPress -= Receive;
        }

        private void Start()
        {
            textComponent = GetComponentInChildren<TextMeshProUGUI>();
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
            textComponent.text += letter;
        }

        private void DeleteLetter()
        {
            var text = textComponent.text;
            if (text.Length <= 0) return;

            textComponent.text = text.Remove(text.Length - 1, 1);
        }

        private void AddSpace()
        {
            textComponent.text += " ";
        }

        private void DeleteEverything()
        {
            textComponent.text = "";
        }
    }

}
