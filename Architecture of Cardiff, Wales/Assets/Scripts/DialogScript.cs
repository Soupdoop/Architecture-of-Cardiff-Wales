using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogScript : MonoBehaviour {

    public InputField levelEntry;
    public MainMenu MenuPlayer;
    /*
    public InputField.SubmitEvent se;

    private void Start() {
        se = new InputField.SubmitEvent();
        se.AddListener(SubmitInput);
        levelEntry.onEndEdit = se;
    }

    private void SubmitInput(string arg) {
        levelEntry.text = "";
        levelEntry.ActivateInputField();

        //MenuPlayer.FindLevel(arg);
    }
    */

    public void ClearText() {
        levelEntry.text = "";
    }
}
