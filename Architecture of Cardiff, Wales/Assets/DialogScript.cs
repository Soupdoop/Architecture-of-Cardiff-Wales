using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogScript : MonoBehaviour {

    public InputField levelEntry;
    public InputField.SubmitEvent se;
    public MainMenu MenuPlayer;

    private void Start() {
        se = new InputField.SubmitEvent();
        se.AddListener(SubmitInput);
        levelEntry.onEndEdit = se;
    }

    private void SubmitInput(string arg) {
        levelEntry.text = "";
        levelEntry.ActivateInputField();

        if (MenuPlayer.FindLevel(arg)) {
            MenuPlayer.PlayGame();
        }
    }

}
