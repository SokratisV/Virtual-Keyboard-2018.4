using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace VirtualKeyboard
{
    [ExecuteInEditMode]
    [DisallowMultipleComponent]
    public partial class ButtonNamer : MonoBehaviour
    {
        [SerializeField] ButtonRowNames englishButtons;
        [SerializeField] ButtonRowNames greekButtons;
        [SerializeField] ButtonRowNames greekButtonsAccent;
        static bool capsToggle = false;
        Dictionary<VirtualKeyboard.KeyboardLanguage, string[]> languageStringsDict = new Dictionary<VirtualKeyboard.KeyboardLanguage, string[]>();
#if UNITY_EDITOR
        [System.Runtime.InteropServices.DllImport("USER32.dll")] public static extern short GetKeyState(int nVirtKey);
        bool IsCapsLockOn => (GetKeyState(0x14) & 1) > 0;
#else
        bool IsCapsLockOn => IsCapsOnWebGL();
#endif
        private string[] currentLanguageStrings;
        public string[] CurrentLanguageStrings
        {
            get
            {
                languageStringsDict.TryGetValue(ChangeActiveLanguage.CurrentLanguage, out var _currentLanguageStrings);
                return _currentLanguageStrings;
            }
            set => currentLanguageStrings = value;
        }

        private void Start()
        {
            if (languageStringsDict.Count == 0)
            {
                languageStringsDict.Add(VirtualKeyboard.KeyboardLanguage.English, englishButtons.buttonNames);
                languageStringsDict.Add(VirtualKeyboard.KeyboardLanguage.Greek, greekButtons.buttonNames);
                if (greekButtonsAccent == null)
                {
                    greekButtonsAccent = greekButtons;
                    languageStringsDict.Add(VirtualKeyboard.KeyboardLanguage.GreekAccent, greekButtonsAccent.buttonNames);
                }
                else
                {
                    languageStringsDict.Add(VirtualKeyboard.KeyboardLanguage.GreekAccent, greekButtonsAccent.buttonNames);
                }
            }

            RefreshKeyboard();
        }

        public void ChangeLanguage()
        {
            RefreshKeyboard();
        }

        public void ToggleCaps()
        {
            capsToggle = !capsToggle;

            foreach (var buttonNamerScript in transform.parent.GetComponentsInChildren<ButtonNamer>())
            {
                buttonNamerScript.RefreshKeyboard();
            }
        }

        private bool IsCapsOnWebGL()
        {
            return capsToggle;
        }

        public void ToggleAccent()
        {
            if (ChangeActiveLanguage.CurrentLanguage == VirtualKeyboard.KeyboardLanguage.Greek)
            {
                ChangeActiveLanguage.CurrentLanguage = VirtualKeyboard.KeyboardLanguage.GreekAccent;
            }
            else if (ChangeActiveLanguage.CurrentLanguage == VirtualKeyboard.KeyboardLanguage.GreekAccent)
            {
                ChangeActiveLanguage.CurrentLanguage = VirtualKeyboard.KeyboardLanguage.Greek;
            }
            foreach (var buttonNamerScript in transform.parent.GetComponentsInChildren<ButtonNamer>())
            {
                buttonNamerScript.RefreshKeyboard();
            }
        }

        private void RefreshKeyboard()
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                ChangeButtonText(i, CurrentLanguageStrings, IsCapsLockOn);
                NameButtonObject(i, CurrentLanguageStrings, IsCapsLockOn);
            }
        }

        /*
        * Changes the text field of each button. Includes upper/lower case conversion.
        */
        private void ChangeButtonText(int childNumber, string[] languageString, bool capsLockOn = false)
        {
            if (capsLockOn)
            {
                transform.GetChild(childNumber).GetChild(0).GetComponent<TextMeshProUGUI>().text = languageString[childNumber];
            }
            else
            {
                transform.GetChild(childNumber).GetChild(0).GetComponent<TextMeshProUGUI>().text =
                    languageString[childNumber].Length > 1 ? languageString[childNumber] : languageString[childNumber].ToLower();
            }
        }
        /*
        * Changes the object's name in the editor to match that of its text.
        */
        private void NameButtonObject(int childNumber, string[] languageString, bool capsLockOn)
        {
            if (capsLockOn)
            {
                transform.GetChild(childNumber).name = languageString[childNumber];
            }
            else
            {
                transform.GetChild(childNumber).name =
                languageString[childNumber].Length > 1 ? languageString[childNumber] : languageString[childNumber].ToLower();
            }
        }
#if UNITY_EDITOR
        private void Update()
        {
            if (Application.isPlaying) return;
            if (languageStringsDict.Count == 0)
            {
                languageStringsDict.Add(VirtualKeyboard.KeyboardLanguage.English, englishButtons.buttonNames);
                languageStringsDict.Add(VirtualKeyboard.KeyboardLanguage.Greek, greekButtons.buttonNames);
            }

            RefreshKeyboard();
        }
#endif
    }
}

