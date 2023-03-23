using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    [SerializeField] CinemachineBrain cinemachineBrain;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F2)) { // Check if the F2 button was pressed
            if(GameIsPaused) { // If the game is paused and the user presses the F2 button unpause
                Resume();
            }
            else { // If the game is not paused and the user presses the F2 button pause
                Pause();
            }
        }
    }

    // Resume is run when the user presses the F2 button and the game is not paused already
    public void Resume() {
        pauseMenuUI.SetActive(false);
        GameIsPaused = false; // Make GameIsPaused false so that if the user presses the F2 button it will pause
        Cursor.visible = false; // Remove the cursor from the screen
        Cursor.lockState = CursorLockMode.Locked; // Make the cursor visible and center it
        cinemachineBrain.enabled = !GameIsPaused; // Unpause the in game movement
        Time.timeScale = 1f; // Unfreeze all of the animations
    }

    // Pause is run when the user presses the F2 button and the game is not paused already
    void Pause() {
        pauseMenuUI.SetActive(true); // Make the pause menu visible
        GameIsPaused = true; // Make GameIsPaused true so that if the user presses the F2 button it will unpause
        Cursor.visible = true; // Make the cursor visible so that the user can press the buttons
        Cursor.lockState = CursorLockMode.None; // Make the cursor visible
        cinemachineBrain.enabled = !GameIsPaused; // Pause the in game movement
        Time.timeScale = 0f; // Freeze all of the animations
    }

    // QuitGame is run when the user presses the Quit button in the pause menu
    public void QuitGame() {
        Debug.Log("Quitting game..."); // Log that the user quit the game
        Application.Quit(); // Quit the application
    }
}
