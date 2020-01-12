using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace VirtualKeyboard
{
    public class KeyPressEventSender : MonoBehaviour
    {
        public static event Action<string> onKeyPress;
        private void OnEnable()
        {
            GetComponent<Button>().onClick.AddListener(() => onKeyPress.Invoke(GetComponentInChildren<TextMeshProUGUI>().text));
        }
        private void OnDisable()
        {
            GetComponent<Button>().onClick.RemoveAllListeners();
        }
    }

}
