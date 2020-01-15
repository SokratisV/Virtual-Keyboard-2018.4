using TMPro;
using UnityEngine;

namespace VirtualKeyboard
{
    public class EnableInputField : MonoBehaviour
    {
        [SerializeField] ReceiveInputField inputField;

        private void Start()
        {
            //remove
            GetComponentInChildren<TextMeshProUGUI>().text = (inputField.IsSubscribed).ToString();
        }

        public void Toggle()
        {
            if (inputField.IsSubscribed) { inputField.Unsubscribe(); }
            else { inputField.Subscribe(); }
            //remove
            GetComponentInChildren<TextMeshProUGUI>().text = (inputField.IsSubscribed).ToString();
        }
    }
}

