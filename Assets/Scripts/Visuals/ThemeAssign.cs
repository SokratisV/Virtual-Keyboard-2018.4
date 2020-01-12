using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace VirtualKeyboard
{
    public class ThemeAssign : MonoBehaviour
    {
        [SerializeField] ThemeComponents component;

        public ThemeComponents Component { get => component; }

        public void ApplyTheme(ColorPallet pallet)
        {
            if (component == ThemeComponents.Text)
            {
                GetComponent<TextMeshProUGUI>().color = pallet.GetColor(component);
            }
            else
            {
                GetComponent<Image>().color = pallet.GetColor(component);
            }
        }
    }
}

