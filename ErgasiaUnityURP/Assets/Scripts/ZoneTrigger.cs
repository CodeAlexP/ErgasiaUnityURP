using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ZoneTrigger : MonoBehaviour
{
    public TextMeshProUGUI zone;
    public string text;
    

    
    void OnTriggerEnter() { // When the user enters a zone add the zone name to the top of the screen
        zone.text = text;
    }

    void OnTriggerExit() { // When the user exits a zone remove the zone name from the top of the screen
        zone.text = "";
    }
}
