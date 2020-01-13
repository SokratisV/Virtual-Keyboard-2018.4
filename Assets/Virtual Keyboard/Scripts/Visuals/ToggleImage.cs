using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleImage : MonoBehaviour
{
    public void ToggleImageMethod()
    {
        Image image = GetComponent<Image>();
        image.enabled = !image.enabled;
    }
}
