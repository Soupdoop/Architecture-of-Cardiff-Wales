using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour {

	public Action<int> requestLevelMusic;

    public void Update() {
        if (Input.GetKeyDown("r")) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void NextLevel(string nextLevel = "") {
        if (nextLevel.Equals("")) {
			if (SceneManager.sceneCountInBuildSettings > SceneManager.GetActiveScene ().buildIndex) {
				int nextLevelNum = SceneManager.GetActiveScene ().buildIndex + 1;
				SceneManager.LoadSceneAsync (nextLevelNum);
				if (requestLevelMusic != null)
					requestLevelMusic (nextLevelNum);
			}
        }
        else {
			SceneManager.LoadSceneAsync(nextLevel);
        }
    }

}
