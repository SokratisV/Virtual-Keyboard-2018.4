using UnityEngine;
using UnityEngine.UI;

namespace VirtualKeyboard
{
    public class SubToVisualFeedback : MonoBehaviour
    {
        void Start()
        {
            VisualFeedback feedbackScript = GetComponentInParent<VisualFeedback>();
            if (feedbackScript == null) { return; }
            GetComponent<Button>().onClick.AddListener(() => feedbackScript.KeyPressedFeedback(GetComponent<Button>()));
        }
    }

}
