using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Virtual_Keyboard.Scripts.Visuals
{
    public class ThemeAssign : MonoBehaviour
    {
        [FormerlySerializedAs("component")] [SerializeField] ThemeComponents componentThemeType;

        public ThemeComponents ComponentThemeType => componentThemeType;

        public void ApplyTheme(ColorPallet pallet)
        {
            if (componentThemeType == ThemeComponents.Text)
            {
                GetComponent<TextMeshProUGUI>().color = pallet.GetColor(componentThemeType);
            }
            else
            {
                GetComponent<Image>().color = pallet.GetColor(componentThemeType);
            }
        }
    }
}

