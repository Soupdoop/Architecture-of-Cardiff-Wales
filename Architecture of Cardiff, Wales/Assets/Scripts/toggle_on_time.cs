using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toggle_on_time : MonoBehaviour {

	public GameObject first;
	public GameObject second;

	public float time_to_switch;
	public float random_mod;

	private float timer;

	// Use this for initialization
	void Start () {
		first.gameObject.SetActive (true);
		second.gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer > time_to_switch) 
		{
			Swap ();
		}
	}

	void Swap()
	{
		bool flop = first.gameObject.activeSelf;
		first.gameObject.SetActive (!flop);
		second.gameObject.SetActive (flop);
		timer = 0.0f - Random.Range(0,random_mod);
	}
}
