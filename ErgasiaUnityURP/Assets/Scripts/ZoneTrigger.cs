using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ZoneTrigger : MonoBehaviour
{
    public TextMeshProUGUI zone;
    public string text;
    

     private void Start() {
         zone = FindObjectOfType<TextMeshProUGUI>();
    }
    void OnTriggerEnter() {
        zone.text = text;
    }

    void OnTriggerExit() {
        zone.text = "";
    }
}
