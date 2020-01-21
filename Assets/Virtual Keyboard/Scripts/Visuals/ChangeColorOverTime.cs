using UnityEngine;
using UnityEngine.UI;

namespace Virtual_Keyboard.Scripts.Visuals
{
    public class ChangeColorOverTime : MonoBehaviour
    {
        [SerializeField] Gradient gradient;
        [SerializeField] float duration = 7f;

        Image _backgroundImage;

        private void Start()
        {
            _backgroundImage = GetComponent<Image>();
        }
        private void Update()
        {
            float t = Mathf.PingPong(Time.time / duration, 1f);
            _backgroundImage.color = gradient.Evaluate(t);
        }
    }

}
