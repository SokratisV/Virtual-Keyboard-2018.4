using RotaryHeart.Lib.SerializableDictionary;
using UnityEngine;

namespace VirtualKeyboard
{
    [ExecuteInEditMode]
    [DisallowMultipleComponent]
    public partial class KeyboardManager : MonoBehaviour
    {
        [SerializeField] KeyboardLanguageEnum currentLanguage = KeyboardLanguageEnum.English;
        [System.Serializable] class LanguagesDictionary : SerializableDictionaryBase<KeyboardLanguageEnum, Language> { };
        [SerializeField] LanguagesDictionary languagesDictionary = new LanguagesDictionary();
        bool capsToggle = false, alternateKeysToggle = false;

#if UNITY_EDITOR
        [System.Runtime.InteropServices.DllImport("USER32.dll")] public static extern short GetKeyState(int nVirtKey);
        bool IsCapsLockOn => (GetKeyState(0x14) & 1) > 0;
#else
        bool IsCapsLockOn => IsCapsOnWebGL();
#endif

        public void ChangeLanguage(KeyboardLanguageEnum language = KeyboardLanguageEnum.None)
        {
            if (language != KeyboardLanguageEnum.None)
            {
                currentLanguage = language;
            }
            else
            {
                //Temporary
                currentLanguage = currentLanguage == KeyboardLanguageEnum.Greek ? KeyboardLanguageEnum.English : KeyboardLanguageEnum.Greek;
            }
            RefreshKeyboard();
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
            print("refreshing");
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

#if UNITY_EDITOR
        // private void Update()
        // {
        //     if (Application.isPlaying) return;
        //     RefreshKeyboard();
        // }
#endif
    }
}

