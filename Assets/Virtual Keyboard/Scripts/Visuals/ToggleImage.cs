using UnityEngine;
using UnityEngine.UI;

namespace Virtual_Keyboard.Scripts.Visuals
{
    public class ToggleImage : MonoBehaviour
    {
        public void ToggleImageMethod()
        {
            var image = GetComponent<Image>();
            image.enabled = !image.enabled;
        }
    }
}
