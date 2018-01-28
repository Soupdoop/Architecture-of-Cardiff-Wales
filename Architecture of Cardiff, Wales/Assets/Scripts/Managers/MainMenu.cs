using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    public Text levelNameText;
    public Dictionary<string, string> levelList = new Dictionary<string, string>() { };

    public void FindLevel(string lvl = "") {
        string levelName = (lvl.Equals("")) ? levelNameText.text : lvl;
        Debug.Log(levelName);
        if (levelList.ContainsKey(levelName)) {
            PlayGame(levelList[levelName]);
        }
    }

    public void PlayGame(string level) {
        //TODO import other saved data
        SceneManager.LoadScene(level);
    }

    public void NewGame() {
        PlayGame("Germ_Training");
    }

    public void QuitGame() {
        Debug.Log("QUIT");
        Application.Quit();
    }
}
