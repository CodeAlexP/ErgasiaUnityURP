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
        if(Input.GetKeyDown(KeyCode.F2)) {
            if(GameIsPaused) {
                Resume();
            }
            else {
                Pause();
            }
        }
    }

    public void Resume() {
        pauseMenuUI.SetActive(false);
        GameIsPaused = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        cinemachineBrain.enabled = !GameIsPaused;
        Time.timeScale = 1f;
    }

    void Pause() {
        pauseMenuUI.SetActive(true);
        GameIsPaused = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        cinemachineBrain.enabled = !GameIsPaused;
        Time.timeScale = 0f;
    }

    public void LoadMenu() {
        Time.timeScale = 1f;
        Debug.Log("Loading menu...");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void QuitGame() {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}
