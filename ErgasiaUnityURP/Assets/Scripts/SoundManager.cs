using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;

    // Start is called before the first frame update
    void Start()
    {
        if(!PlayerPrefs.HasKey("musicVolume")) { // If there aren't user preferences present
            PlayerPrefs.SetFloat("musicVolume", 1); // Set the volume of the music to max
            Load(); // Load the prefered volume
        }
        else { // If there aren user preferences present
            Load(); // Load the prefered volume
        }
    }

    // Save is run when the user changes the volume from the slider in the options menu in main menu
    public void ChangeVolume() {
        AudioListener.volume = volumeSlider.value; // Get the value of the volume slider
        Save(); // Save the picked volume
    }

    // Load is run when the options menu is shown
    private void Load() { 
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume"); // Get the volume preference of the user
    }

    // Save is run when the user changes the volume from the slider in the options menu in main menu
    private void Save() { 
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value); // Save the volume preference of the user
    }
}
