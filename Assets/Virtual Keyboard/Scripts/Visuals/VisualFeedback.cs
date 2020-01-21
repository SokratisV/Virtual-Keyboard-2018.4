using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Virtual_Keyboard.Scripts.Visuals
{
    public class VisualFeedback : MonoBehaviour
    {
        // Should be the same to sync up "animation".
        [SerializeField] float scaleDuration = .15f, colorChangeDuration = .15f, scaleFactor = .9f;
        [SerializeField] bool scaleFeedbackActive = true, colorFeedbackActive = true;
        Color _feedbackColor;

        /*
        * 0 -> ScaleKey
        * 1 -> ColorChange
        */
        readonly bool[] _haveCoroutinesStarted = new bool[2];
        KeyboardThemeManager _keyboardThemeManager;

        private void Start()
        {
            _keyboardThemeManager = GetComponentInParent<KeyboardThemeManager>();
            Color color = GetComponent<Image>().color;
            _feedbackColor = new Color(color.r * 0.5f, color.g * 0.5f, color.b * 0.5f);
        }

        public void KeyPressedFeedback(Button button)
        {
            if (scaleFeedbackActive) { StartCoroutine(ScaleKey(button)); }
            if (colorFeedbackActive) { StartCoroutine(ColorChange(button)); }
        }

        private IEnumerator ScaleKey(Button button)
        {
            _haveCoroutinesStarted[0] = true;
            button.transform.localScale = new Vector3(scaleFactor, scaleFactor, 1); ;
            yield return new WaitForSeconds(scaleDuration);
            button.transform.localScale = Vector3.one;
            _haveCoroutinesStarted[0] = false;
        }

        private IEnumerator ColorChange(Component button)
        {
            _haveCoroutinesStarted[1] = true;
            var buttonImage = button.GetComponent<Image>();
            var currentColor = _keyboardThemeManager.GetComponentColor(button.GetComponent<ThemeAssign>().ComponentThemeType);
            var time = 0f;

            while (time < 1)
            {
                time += Time.deltaTime / colorChangeDuration;
                buttonImage.color = Color.Lerp(_feedbackColor, currentColor, time);
                yield return null;
            }
            _haveCoroutinesStarted[1] = false;
        }
    }

}
