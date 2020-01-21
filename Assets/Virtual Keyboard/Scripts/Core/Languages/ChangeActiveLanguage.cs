using UnityEngine;
using UnityEngine.UI;

namespace Virtual_Keyboard.Scripts.Core.Languages
{
    public class ChangeActiveLanguage : MonoBehaviour
    {
        [SerializeField] Image leftImage, rightImage;
        [Range(0, 1)] [SerializeField] float transparencyValue = .3f;
        [SerializeField] bool leftPanelActive = false, rightPanelActive = true;
        KeyboardManager _keyboardManager;

        private void Start()
        {
            _keyboardManager = FindObjectOfType<KeyboardManager>();
        }

        private void Update()
        {
            if (Input.GetKey(KeyCode.LeftAlt))
            {
                if (Input.GetKeyDown(KeyCode.LeftShift))
                {
                    ChangeLanguage();
                }
            }
        }

        public void ChangeLanguage()
        {
            _keyboardManager.ChangeLanguage();
            ToggleTransparency(leftImage, ref leftPanelActive);
            ToggleTransparency(rightImage, ref rightPanelActive);
        }

        private void ToggleTransparency(Image image, ref bool active)
        {
            var panelColor = image.color;
            var flagImageColor = image.transform.GetChild(0).GetComponent<Image>().color;
            panelColor.a = active ? transparencyValue : 1f;
            flagImageColor.a = active ? transparencyValue : 1f;

            image.color = panelColor;
            image.transform.GetChild(0).GetComponent<Image>().color = flagImageColor;

            active = !active;
        }
    }
}

