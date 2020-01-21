using UnityEngine;
using Virtual_Keyboard.Rotary_Heart.SerializableDictionary;
using Virtual_Keyboard.Scripts.Core.Languages;

namespace Virtual_Keyboard.Scripts.Core
{
    [DisallowMultipleComponent]
    public partial class KeyboardManager : MonoBehaviour
    {
        [SerializeField] KeyboardLanguageEnum currentLanguage = KeyboardLanguageEnum.English;
        [System.Serializable] class LanguagesDictionary : SerializableDictionaryBase<KeyboardLanguageEnum, Language> { };
        [SerializeField] LanguagesDictionary languagesDictionary = new LanguagesDictionary();
        bool _capsToggle = false, _alternateKeysToggle = false;
        KeyboardLanguageEnum _previousLanguage = KeyboardLanguageEnum.None;
        KeyboardRowManager[] _keyboardRowManagers;

#if UNITY_EDITOR
        private void Start()
        {
            _keyboardRowManagers = GetComponentsInChildren<KeyboardRowManager>();
        }

        [System.Runtime.InteropServices.DllImport("USER32.dll")] public static extern short GetKeyState(int nVirtKey);
        bool IsCapsLockOn => (GetKeyState(0x14) & 1) > 0 || _capsToggle;
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
                    currentLanguage = _previousLanguage;
                    _previousLanguage = KeyboardLanguageEnum.None;
                }
                else
                {
                    //Change to symbols and remember language
                    _previousLanguage = currentLanguage;
                    currentLanguage = language;
                }
            }
            else if (language != KeyboardLanguageEnum.None)
            {
                currentLanguage = language;
                _previousLanguage = KeyboardLanguageEnum.None;
            }
            else
            {
                //Temporary
                if (currentLanguage == KeyboardLanguageEnum.Symbols)
                {
                    currentLanguage = _previousLanguage;
                    _previousLanguage = KeyboardLanguageEnum.None;
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
            _capsToggle = !_capsToggle;

            RefreshKeyboard();
        }

        public void ToggleAlternateKeys()
        {
            _alternateKeysToggle = !_alternateKeysToggle;

            RefreshKeyboard();
        }

        public void RefreshKeyboard()
        {
            languagesDictionary.TryGetValue(currentLanguage, out var languageAsset);
            foreach (var manager in _keyboardRowManagers)
            {
                manager.RefreshRow(languageAsset, IsCapsLockOn, _alternateKeysToggle);
            }
        }

        private bool IsCapsOnWebGL()
        {
            return _capsToggle;
        }
    }
}

