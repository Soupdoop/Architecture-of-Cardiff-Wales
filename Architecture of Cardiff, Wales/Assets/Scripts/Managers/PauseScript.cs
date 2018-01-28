using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour {

    public static bool GameIsPaused = false;

    public GameObject pauseMenu;

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown("p") || Input.GetKeyDown(KeyCode.Escape)) {
            if (GameIsPaused) {
                Resume();
            }
            else {
                Pause();
            }
        }
    }

    void Pause() {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Resume() {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void LoadMenu() {
		GameObject sceneMgmr = GameObject.FindGameObjectWithTag ("SceneHandler");
		if (sceneMgmr != null)
			sceneMgmr.GetComponent<SceneHandler> ().NextLevel ("MainMenu");
        Resume();
        Debug.Log("MAIN MENU");
    }

    public void QuitGame() {
        Debug.Log("QUIT");
        Application.Quit();
    }
}
