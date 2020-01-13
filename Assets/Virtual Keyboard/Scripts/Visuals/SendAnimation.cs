using TMPro;
using UnityEngine;

namespace VirtualKeyboard
{
    public class SendAnimation : MonoBehaviour
    {
        TextMeshProUGUI text;
        Animator animator;

        private void Start()
        {
            text = GetComponent<TextMeshProUGUI>();
            animator = GetComponent<Animator>();
        }

        public void AnimateText()
        {
            animator.Play("TextSendAnimation");
        }

        // Animation event
        public void DeleteText()
        {
            GetComponentInParent<ReceiveInput>().DeleteEverything();
        }
    }
}

