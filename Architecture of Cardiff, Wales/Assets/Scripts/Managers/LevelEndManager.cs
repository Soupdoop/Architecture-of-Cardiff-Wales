using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEndManager : MonoBehaviour {

	public Activatable[] goals;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		bool ready = true;
		for (int i = 0; i < goals.Length; i++) {
			if (!goals [i].hasBeenActivated) {
				ready = false;
			}
		}
		if (ready) {
			Debug.Log ("LEVEL DONE");
		}
	}
}
