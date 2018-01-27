using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    public Text levelNameText;

    public void FindLevel(string lvl = "") {
        string levelName = (lvl.Equals("")) ? levelNameText.text : lvl;
        Debug.Log(levelName);
        //Match levelname to levellist
        //Play game @ that level
    }

    public void PlayGame() {
        SceneManager.LoadScene("Main");
    }

    public void NewGame() {
        //RESET PROGRESS, START FROM FIRST LEVEL
    }

    public void QuitGame() {
        Debug.Log("QUIT");
        Application.Quit();
    }
}
