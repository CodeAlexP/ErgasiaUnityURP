using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitGame : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) { // Check if the Escape button was pressed
            Time.timeScale = 1f; // Make the game run at normal speed
            Debug.Log("Loading menu..."); // Log that the main menu is loading
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None; // Make the cursor visible
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1); // Change the scene to the main menu scene
        }
    }
}
