using UnityEngine;
using UnityEngine.UI;

namespace VirtualKeyboard
{
    public class ChangeColorOverTime : MonoBehaviour
    {
        [SerializeField] Gradient gradient;
        [SerializeField] float duration = 7f;

        Image backgroundImage;

        private void Start()
        {
            backgroundImage = GetComponent<Image>();
        }
        private void Update()
        {
            float t = Mathf.PingPong(Time.time / duration, 1f);
            backgroundImage.color = gradient.Evaluate(t);
        }
    }

}
