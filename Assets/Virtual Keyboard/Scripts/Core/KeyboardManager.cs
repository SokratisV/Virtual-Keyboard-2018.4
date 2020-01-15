using RotaryHeart.Lib.SerializableDictionary;
using UnityEngine;

namespace VirtualKeyboard
{
    [DisallowMultipleComponent]
    public partial class KeyboardManager : MonoBehaviour
    {
        [SerializeField] KeyboardLanguageEnum currentLanguage = KeyboardLanguageEnum.English;
        [System.Serializable] class LanguagesDictionary : SerializableDictionaryBase<KeyboardLanguageEnum, Language> { };
        [SerializeField] LanguagesDictionary languagesDictionary = new LanguagesDictionary();
        bool capsToggle = false, alternateKeysToggle = false;
        KeyboardLanguageEnum previousLanguage = KeyboardLanguageEnum.None;

#if UNITY_EDITOR
        [System.Runtime.InteropServices.DllImport("USER32.dll")] public static extern short GetKeyState(int nVirtKey);
        bool IsCapsLockOn => ((GetKeyState(0x14) & 1) > 0 || capsToggle);
#else
        bool IsCapsLockOn => IsCapsOnWebGL();
#endif

        public void ChangeLanguage(KeyboardLanguageEnum language = KeyboardLanguageEnum.None)
        {
            if (language == KeyboardLanguageEnum.Symbols)
            {
                if (currentLanguage == KeyboardLanguageEnum.Symbols)
                {
                    //Revert to prev language
                    currentLanguage = previousLanguage;
                    previousLanguage = KeyboardLanguageEnum.None;
                }
                else
                {
                    //Change to symbols and remember language
                    previousLanguage = currentLanguage;
                    currentLanguage = language;
                }
            }
            else if (language != KeyboardLanguageEnum.None)
            {
                currentLanguage = language;
                previousLanguage = KeyboardLanguageEnum.None;
            }
            else
            {
                //Temporary
                if (currentLanguage == KeyboardLanguageEnum.Symbols)
                {
                    currentLanguage = previousLanguage;
                    previousLanguage = KeyboardLanguageEnum.None;
                }
                currentLanguage = currentLanguage == KeyboardLanguageEnum.Greek ? KeyboardLanguageEnum.English : KeyboardLanguageEnum.Greek;
            }
            RefreshKeyboard();
        }

        /*
        * Separate method to be assigned in the editor because you can't have Enums as params in editor OnClicks.
        */
        public void ToggleSymbols()
        {
            ChangeLanguage(KeyboardLanguageEnum.Symbols);
        }

        public void ToggleCaps()
        {
            capsToggle = !capsToggle;

            RefreshKeyboard();
        }

        public void ToggleAlternateKeys()
        {
            alternateKeysToggle = !alternateKeysToggle;

            RefreshKeyboard();
        }

        public void RefreshKeyboard()
        {
            print("Refreshing Keyboard");
            languagesDictionary.TryGetValue(currentLanguage, out var languageAsset);
            foreach (KeyboardRowManager manager in GetComponentsInChildren<KeyboardRowManager>())
            {
                manager.RefreshRow(languageAsset, IsCapsLockOn, alternateKeysToggle);
            }
        }

        private bool IsCapsOnWebGL()
        {
            return capsToggle;
        }
    }
}

