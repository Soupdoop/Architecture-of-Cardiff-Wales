using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

	public Activatable[] goals;

	public GameManager gm;

    private bool done = false;

	// Use this for initialization
	void Start () {
		gm = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameManager> ();
	}

	// Update is called once per frame
	void Update () {
		bool ready = true;
		for (int i = 0; i < goals.Length; i++) {
			if (!goals [i].hasBeenActivated) {
				ready = false;
			}
		}
		if (ready && !done) {
            done = true;
			gm.TransitionAnim ();
		}
	}
}