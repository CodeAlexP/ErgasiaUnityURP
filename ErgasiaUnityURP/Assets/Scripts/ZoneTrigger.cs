using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ZoneTrigger : MonoBehaviour
{
    public TextMeshProUGUI zone = FindObjectOfType<TextMeshProUGUI>();
    public string text;

    void OnTriggerEnter() {
        zone.text = text;
    }

    void OnTriggerExit() {
        zone.text = "";
    }
}
