using TMPro;
using UnityEngine;
using Virtual_Keyboard.Scripts.Misc;

namespace Virtual_Keyboard.Scripts.Visuals
{
    public class SendAnimation : MonoBehaviour
    {
        Animator _animator;

        private void Start()
        {
            _animator = GetComponent<Animator>();
        }

        public void AnimateText()
        {
            _animator.Play("TextSendAnimation");
        }

        // Animation event
        public void DeleteText()
        {
            GetComponentInParent<ReceiveInput>().DeleteEverything();
        }
    }
}

