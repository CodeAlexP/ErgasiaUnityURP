using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class HelpScreen : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject helpScreenUI;
    public GameObject Minimap;
     public GameObject Healtbar;
    
    [SerializeField] CinemachineBrain cinemachineBrain;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F1)) { // Check if the F1 button was pressed
            if(GameIsPaused) {
                Resume();
            }
            else {
                Pause();
            }
        }
    }

    public void Resume() {
        helpScreenUI.SetActive(false);
        GameIsPaused = false; // Make GameIsPaused false so that if the user presses the F1 button it will pause
        Cursor.visible = false; // Remove the cursor from the screen
        Cursor.lockState = CursorLockMode.Locked; // Make the cursor visible and center it
        cinemachineBrain.enabled = !GameIsPaused; // Unpause the in game movement
        Time.timeScale = 1f; // Unfreeze all of the animations
        Minimap.SetActive(true);
        Healtbar.SetActive(true);
    }

    void Pause() {
         Minimap.SetActive(false);
        Healtbar.SetActive(false);
        helpScreenUI.SetActive(true); // Make the pause menu visible
        GameIsPaused = true; // Make GameIsPaused true so that if the user presses the F1 button it will unpause
        Cursor.visible = true; // Make the cursor visible so that the user can press the buttons
        Cursor.lockState = CursorLockMode.None; // Make the cursor visible
        cinemachineBrain.enabled = !GameIsPaused; // Pause the in game movement
        Time.timeScale = 0f; // Freeze all of the animations
    }
}
