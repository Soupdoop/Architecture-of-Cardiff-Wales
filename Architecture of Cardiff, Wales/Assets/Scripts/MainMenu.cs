using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public bool FindLevel(string levelName) {
        return false;
    }

    public void PlayGame() {
        SceneManager.LoadScene("Main");
    }

    public void QuitGame() {
        Debug.Log("QUIT");
        Application.Quit();
    }
}
