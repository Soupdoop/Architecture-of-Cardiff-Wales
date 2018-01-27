using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class MusicMgmr : MonoBehaviour {

	public AudioMixer master;
	public TRACKS listener;	
	private TRACKS cached;

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
		AllOff ();
		ChangeAudioMode ();
	}
	
	// Update is called once per frame
	void Update () {
		if (cached != listener) {
			ChangeAudioMode ();
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
			break;
		case(TRACKS.WORM):
			break;
		case(TRACKS.TROUBLE):
			break;
		case(TRACKS.HARP):
			break;
		case(TRACKS.MARIMBAS):
			break;
		default:
			break;

		}
	}

	void AllOff()
	{
		master.SetFloat("volume", -80.0f);
		master.SetFloat("drumvol", -80.0f);
		master.SetFloat("back1vol", -80.0f);
		master.SetFloat("back2vol", -80.0f);
		master.SetFloat("snarevol", -80.0f);
		master.SetFloat("kickvol", -80.0f);
		master.SetFloat("fxvol", -80.0f);
		master.SetFloat("breathvol", -80.0f);
		master.SetFloat("tracksvol", -80.0f);
		master.SetFloat("introvol", -80.0f);
		master.SetFloat("darkvol", -80.0f);
		master.SetFloat("wormvol", -80.0f);
		master.SetFloat("troublevol", -80.0f);
		master.SetFloat("harpvol", -80.0f);
		master.SetFloat("marimbasvol", -80.0f);

	}
}
