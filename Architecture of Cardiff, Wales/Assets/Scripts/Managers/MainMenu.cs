using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    public Text levelNameText;
    public Dictionary<string, string> levelList = new Dictionary<string, string>() {
        { "GemsTaining", "Germ_Training"},
        { "GemsNext", "Germ_next"},
        { "GemsBlood", "Germ_Blood"},
        { "GemsFinal", "GermFinal"},
        { "AtTaining", "RatTraining"},
        { "AtTaining2", "RatTraining2"},
        { "AtLevel3", "RatLevel3"},
        { "AtLevel4", "RatLevel4"},
        { "HumanTaining", "HumanTraining"},
        { "ZACH", "Zach1"},
        { "PigeonTaining", "PigeonTraining"},
        { "City_Elevato", "City_Elevator"},
        { "City_Final", "City_Final"},
        { "TainMobandCa", "TrainMobAndCar"},
        { "TainPlaneAndTain", "TrainPlaneAndTrain"},
        { "CountyOne", "Country....... One"},
        { "HazmatTaining", "HazmatTraining"},
        { "CountyFun", "CountryFun"},
        { "GalaxyTaining", "GalaxyTraining"}
    };

    public void FindLevel(string lvl = "") {
        string levelName = (lvl.Equals("")) ? levelNameText.text : lvl;
        Debug.Log(levelName);
        if (levelList.ContainsKey(levelName)) {
            PlayGame(levelList[levelName]);
        }
    }

    public void PlayGame(string level) {
        //TODO import other saved data
		GameObject sceneMgmr = GameObject.FindGameObjectWithTag ("SceneHandler");
		if (sceneMgmr != null)
			sceneMgmr.GetComponent<SceneHandler> ().NextLevel (level);
    }

    public void NewGame() {
        PlayGame("Germ_Training");
    }

    public void QuitGame() {
        Debug.Log("QUIT");
        Application.Quit();
    }
}
