using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager control;

    public SceneHandler sceneHandler;
	public MusicMgmr musicMgmr;

    public GameObject canvasObj;
    private Canvas playCanvas;

    public GameObject transitionScreen;

    private void Awake() {
        if (control == null) {
            DontDestroyOnLoad(transform.gameObject);
            control = this;
        }
        else if (control != this) {
            Destroy(gameObject);
        }
    }

    public void Start() {
        playCanvas = canvasObj.GetComponent<Canvas>();
		sceneHandler.requestLevelMusic = (int level) => {
			musicMgmr.LevelToMode (level);
		};
    }

    public void DisablePause(bool cantPause) {
        canvasObj.SetActive(cantPause);
    }

    public void TransitionAnim() {
        transitionScreen.SetActive(true);
    }

    public void NextLevel() {
        transitionScreen.SetActive(false);
        sceneHandler.NextLevel();
    }
}
