using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager control;

    public SceneHandler sceneHandler;
	public MusicMgmr musicMgmr;

    public GameObject canvasObj;
    private Canvas playCanvas;

    public PauseScript pauseScript;

    public GameObject transitionScreen;

    private string[] LevelKeys =
    {
                  "SPUNKYMONKEY",
         "GemsTaining",
         "GemsNext",
         "GemsBlood", 
         "GemsFinal", 
         "AtTaining", 
         "AtTaining2",
         "AtLevel3", 
         "AtLevel4", 
         "HumanTaining", 
         "ZACH", 
         "PigeonTaining", 
         "City_Elevato", 
         "City_Final", 
         "TainMobandCa",
         "TainPlaneAndTain", 
         "CountyOne", 
         "HazmatTaining", 
         "CountyFun", 
         "GalaxyTain", 
         "GalaxyTainAsteoid",
         "MediumAsteoid", 
         "GalaxyTainWell", 
         "GalaxyMediumWell",
         "GalaxyFinal",
         "UniveseTaining", 
         "Univese2", 
         "Univese3", 
         "UniveseFinal"
    };

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
        sceneHandler.NextLevel();
    }

    private void OnLevelWasLoaded(int level) {
        string levelName = LevelKeys[SceneManager.GetActiveScene().buildIndex];
        pauseScript.SetLevelKey(levelName);
        transitionScreen.SetActive(false);
    }
}
