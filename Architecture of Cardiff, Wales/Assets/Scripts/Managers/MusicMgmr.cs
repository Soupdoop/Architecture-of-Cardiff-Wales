﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class MusicMgmr : MonoBehaviour {

	public AudioMixer master;
	public TRACKS listener;	
	private TRACKS cached;

	string[] vols = {"drumsvol","back1vol","back2vol","snarevol",
		"kickvol","fxvol","breathvol","tracksvol","introvol",
		"darkvol","wormvol","troublevol","harpvol","marimbasvol"};

	public float change_per_second;

	void Awake() {
		DontDestroyOnLoad(this.gameObject);
	}

	public enum TRACKS {
		INTRO,
		DARK,
		WORM,
		TROUBLE,
		HARP,
		MARIMBAS
	}

	// Use this for initialization
	void Start () {
		cached = listener;
		AllOffNOW ();
		ChangeAudioMode ();
	}
	
	// Update is called once per frame
	void Update () {
		if (cached != listener) {
			ChangeAudioMode ();
		}
		cached = listener;
		if (UnityEngine.Input.GetKeyDown (KeyCode.T)) {
			Debug.LogError ("changing tracks");
			listener = TRACKS.HARP;
		}
	}

	public void LevelToMode(int nextLevel)
	{
		//Debug.LogError ("Changing Music");
		if (nextLevel == 0 && nextLevel > -1) {
			AllOffNOW ();
			listener = TRACKS.INTRO;
			GameObject.FindGameObjectWithTag ("GGJ").GetComponent<AudioSource> ().Play ();
		}
		else if (nextLevel < 5) {
			listener = TRACKS.HARP;
		} else if (nextLevel < 10) {
			listener = TRACKS.DARK;
		} else if (nextLevel < 14) {
			listener = TRACKS.MARIMBAS;
		} else if (nextLevel < 19) {
			listener = TRACKS.TROUBLE;
		} else if (nextLevel < 23) {
			listener = TRACKS.WORM;
		}
	}

	void ChangeAudioMode()
	{
		switch (listener) 
		{
		case(TRACKS.INTRO):
			master.SetFloat("volume", 0.0f);
			master.SetFloat ("tracksvol", 0.0f);
			master.SetFloat ("ggjvol", 0.0f);
			break;
		case(TRACKS.DARK):
			string[] temp = {"drumsvol","back1vol","back2vol","snarevol","kickvol","tracksvol","darkvol"};
			TransitionUp(temp);
			break;
		case(TRACKS.WORM):
			string[] temp1 = {"drumsvol","back1vol","back2vol","snarevol","kickvol","tracksvol","wormvol"};
			TransitionUp(temp1);
			break;
		case(TRACKS.TROUBLE):
			string[] temp2 = {"drumsvol","back1vol","back2vol","snarevol","kickvol","tracksvol","troublevol"};
			TransitionUp(temp2);
			break;
		case(TRACKS.HARP):
			string[] temp3 = {"drumsvol","kickvol","tracksvol","harpvol"};
			TransitionUp(temp3);
			break;
		case(TRACKS.MARIMBAS):
			string[] temp4 = {"drumsvol","back1vol","kickvol","tracksvol","marimbasvol"};
			TransitionUp(temp4);
			break;
		default:
			break;
		
		

		}
	}

	void TransitionUp(string[] up) // all others down
	{
		foreach (string samson in vols) {
			bool turnOff = true;
			foreach (string bernard in up) {
				if (samson == bernard) {
					turnOff = false;
				}
			}
			if (turnOff) 
			{
				StartCoroutine(FadeAudioDown (samson, -80.0f));
			} 
			else 
			{
				//Debug.LogWarning ("Turning Up " + samson);
				StartCoroutine(FadeAudioUp (samson, 0.0f));
			}
		}
	}

	void AllOffNOW()
	{
		master.SetFloat("volume", -80.0f);
		foreach (string samson in vols) 
		{
			master.SetFloat(samson, -80.0f);
		}
	}

	public IEnumerator FadeAudioUp(string voltrack, float to)
	{
		float current = 0.0f;
		master.GetFloat (voltrack, out current);
		while (current < to) 
		{
			//Debug.Log ("*** turning up " + voltrack);
			master.GetFloat (voltrack, out current);
			master.SetFloat (voltrack, current + change_per_second * Time.deltaTime);
			yield return null;
		} 
	}

	public IEnumerator FadeAudioDown(string voltrack, float to)
	{
		float current = 0.0f;
		master.GetFloat (voltrack, out current);
		while (current > to) 
		{
			master.GetFloat (voltrack, out current);
			master.SetFloat (voltrack, current - change_per_second * Time.deltaTime);
			yield return null;
		} 
	}
}
