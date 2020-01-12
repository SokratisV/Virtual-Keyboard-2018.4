using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace VirtualKeyboard
{
    public class VisualFeedback : MonoBehaviour
    {
        // Should be the same to sync up "animation".
        [SerializeField] float scaleDuration = .15f, colorChangeDuration = .15f, scaleFactor = .9f;
        [SerializeField] bool scaleFeedbackActive = true, colorFeedbackActive = true;
        Color feedbackColor;

        /*
        * 0 -> ScaleKey
        * 1 -> ColorChange
        */
        bool[] haveCoroutinesStarted = new bool[2];

        private void Start()
        {
            Color color = GetComponent<Image>().color;
            feedbackColor = new Color(color.r * 0.5f, color.g * 0.5f, color.b * 0.5f);
        }

        public void KeyPressedFeedback(Button button)
        {
            if (scaleFeedbackActive) { StartCoroutine(ScaleKey(button)); }
            if (colorFeedbackActive) { StartCoroutine(ColorChange(button)); }
        }

        private IEnumerator ScaleKey(Button button)
        {
            haveCoroutinesStarted[0] = true;
            button.transform.localScale = new Vector3(scaleFactor, scaleFactor, 1); ;
            yield return new WaitForSeconds(scaleDuration);
            button.transform.localScale = Vector3.one;
            haveCoroutinesStarted[0] = false;
        }

        private IEnumerator ColorChange(Button button)
        {
            haveCoroutinesStarted[1] = true;
            Image buttonImage = button.GetComponent<Image>();
            Color currentColor = GetComponentInParent<KeyboardThemeManager>().GetComponentColor(button.GetComponent<ThemeAssign>().Component);
            float time = 0f;

            while (time < 1)
            {
                time += Time.deltaTime / colorChangeDuration;
                buttonImage.color = Color.Lerp(feedbackColor, currentColor, time);
                yield return null;
            }
            haveCoroutinesStarted[1] = false;
        }
    }

}
