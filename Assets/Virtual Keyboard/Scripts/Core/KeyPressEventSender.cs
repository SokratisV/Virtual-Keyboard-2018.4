using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Virtual_Keyboard.Scripts.Core
{
    public class KeyPressEventSender : MonoBehaviour
    {
        public static event Action<string> OnKeyPress;
        private void OnEnable()
        {
            GetComponent<Button>().onClick.AddListener(() => OnKeyPress?.Invoke(GetComponentInChildren<TextMeshProUGUI>().text));
        }
        private void OnDisable()
        {
            GetComponent<Button>().onClick.RemoveAllListeners();
        }
    }

}
