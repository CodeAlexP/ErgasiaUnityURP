using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // PlayGame is run when the user presses the Play button in the main menu
    public void PlayGame() {
        Cursor.visible = false; // Remove the cursor from the screen when the game starts
        Cursor.lockState = CursorLockMode.Locked; // Remove the cursor from the screen and center it
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // Change to the scene with the game
    }

    // QuitGame is run when the user presses the Quit button in the main menu
    public void QuitGame() {
        Debug.Log("QUIT!"); // Log that the user quit the game
        Application.Quit(); // Quit the application
    }
}
