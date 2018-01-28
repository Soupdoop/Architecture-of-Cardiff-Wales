using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour {

    public void Update() {
        if (Input.GetKeyDown("r")) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void NextLevel(string nextLevel = "") {
        if (nextLevel.Equals("")) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else {
            SceneManager.LoadScene(nextLevel);
        }
    }

}
