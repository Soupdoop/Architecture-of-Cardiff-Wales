using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager control;

    public GameObject canvasObj;
    private Canvas playCanvas;

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
    }

    /*public void OnLevelWasLoaded(int level) {
        if (level == 1) {
            DisablePause(true);
        }
        else {
            DisablePause(false);
        }
    }*/

    public void DisablePause(bool cantPause) {
        canvasObj.SetActive(cantPause);
    }
}
