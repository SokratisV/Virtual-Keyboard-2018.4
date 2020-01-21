using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Virtual_Keyboard.Scripts.Core.Languages;

namespace Virtual_Keyboard.Scripts.Core
{
    public class KeyboardRowManager : MonoBehaviour
    {
        // Assign in inspector from 1 to 5
        [SerializeField] int rowNumber;
        public void RefreshRow(Language languageAsset, bool capsLockOn, bool alternateKeys)
        {
            string[] buttonNames = languageAsset.GetRow(rowNumber - 1, alternateKeys).buttonNames;
            ChangeButtonText(buttonNames, capsLockOn);
            NameButtonObject(buttonNames, capsLockOn);
        }

        /*
        * Changes the text field of each button. Includes upper/lower case conversion.
        */
        private void ChangeButtonText(IReadOnlyList<string> languageString, bool capsLockOn = false)
        {
            for (int childNumber = 0; childNumber < transform.childCount; childNumber++)
            {
                if (capsLockOn)
                {
                    transform.GetChild(childNumber)
                        .GetChild(0)
                        .GetComponent<TextMeshProUGUI>()
                        .text = languageString[childNumber];
                }
                else
                {
                    transform.GetChild(childNumber).GetChild(0).GetComponent<TextMeshProUGUI>().text =
                        languageString[childNumber].Length > 1
                            ? languageString[childNumber]
                            : languageString[childNumber].ToLower();
                }
            }
        }

        /*
        * Changes the object's name in the editor to match that of its text.
        */
        private void NameButtonObject(IReadOnlyList<string> languageString, bool capsLockOn)
        {
            for (var childNumber = 0; childNumber < transform.childCount; childNumber++)
            {
                if (capsLockOn)
                {
                    transform.GetChild(childNumber).name = languageString[childNumber];
                }
                else
                {
                    transform.GetChild(childNumber).name =
                        languageString[childNumber].Length > 1 ? languageString[childNumber] : languageString[childNumber].ToLower();
                }
            }
        }
    }
}

