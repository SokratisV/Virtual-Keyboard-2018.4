using UnityEngine;
using UnityEngine.UI;

namespace Virtual_Keyboard.Scripts.Visuals
{
    public class SubToVisualFeedback : MonoBehaviour
    {
        void Start()
        {
            var feedbackScript = GetComponentInParent<VisualFeedback>();
            if (feedbackScript == null) { return; }
            GetComponent<Button>().onClick.AddListener(() => feedbackScript.KeyPressedFeedback(GetComponent<Button>()));
        }
    }

}
