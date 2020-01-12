using RotaryHeart.Lib.SerializableDictionary;
using UnityEngine;
namespace VirtualKeyboard
{
    public enum ThemeComponents
    {
        Background,
        SmallKey,
        MediumKeyNormal,
        MediumKeyDanger,
        MediumKeyConfirm,
        Spacebar,
        Text,
    }
    [System.Serializable]
    public struct ColorPallet
    {
        [SerializeField]
        Color backgroundColor, smallKeysColor,
            mediumKeysNormalColor, mediumKeysDangerColor, mediumKeysConfirmColor,
            spacebarColor, textColor;



        public Color GetColor(ThemeComponents component)
        {
            switch (component)
            {
                case ThemeComponents.Background:
                    return backgroundColor;
                case ThemeComponents.SmallKey:
                    return smallKeysColor;
                case ThemeComponents.MediumKeyNormal:
                    return mediumKeysNormalColor;
                case ThemeComponents.MediumKeyConfirm:
                    return mediumKeysConfirmColor;
                case ThemeComponents.MediumKeyDanger:
                    return mediumKeysDangerColor;
                case ThemeComponents.Spacebar:
                    return spacebarColor;
                case ThemeComponents.Text:
                    return textColor;
                default:
                    return Color.black;
            }
        }
    }
    [ExecuteInEditMode]
    public class KeyboardThemeManager : MonoBehaviour
    {
        public enum Themes
        {
            Dark,
            Light,
            Midnight
        }
        [System.Serializable]
        class KeyboardThemeDictionary : SerializableDictionaryBase<Themes, ColorPallet> { }

        [SerializeField] KeyboardThemeDictionary themes = new KeyboardThemeDictionary();
        [SerializeField] Themes currentTheme = Themes.Dark;

        private void Start()
        {
            ChangeToNextTheme();
        }

        public Color GetComponentColor(ThemeComponents component)
        {
            themes.TryGetValue(currentTheme, out var _colorPallet);
            return _colorPallet.GetColor(component);
        }

        public void ChangeToNextTheme()
        {
            currentTheme++;
            if ((int)currentTheme > System.Enum.GetNames(typeof(Themes)).Length - 1)
            {
                currentTheme = Themes.Dark;
            }
            foreach (var themable in GetComponentsInChildren<ThemeAssign>())
            {
                if (themes.TryGetValue(currentTheme, out var colorPallet))
                    themable.ApplyTheme(colorPallet);
            }
        }
        public void ChangeToTheme(Themes theme)
        {
            currentTheme = theme;
            foreach (var themable in GetComponentsInChildren<ThemeAssign>())
            {
                if (themes.TryGetValue(currentTheme, out var colorPallet))
                    themable.ApplyTheme(colorPallet);
            }
        }
#if UNITY_EDITOR
        private void Update()
        {
            if (Application.isPlaying) return;
            ChangeToTheme(currentTheme);
        }
#endif
    }
}

