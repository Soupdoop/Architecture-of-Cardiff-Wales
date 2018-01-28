using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject mainCanvas;

    private void Awake() {
        DontDestroyOnLoad(transform.gameObject);
    }

    public void DisablePause(bool canPause) {
        mainCanvas.SetActive(canPause);
    }
}
