using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poop_out : MonoBehaviour {

	public List<GameObject> generate;
	public float seconds_per_poop;
	public float random_extension_factor;

	private float timer;
	private float decided_extension_factor;

	// Use this for initialization
	void Start () {
		if (generate.Count > 0) 
		{
			Poop ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer >= seconds_per_poop + decided_extension_factor) {
			Poop ();
		}
	}

	void Poop()
	{
		GameObject.Instantiate<GameObject> (generate [Random.Range (0, generate.Count)], this.gameObject.transform);
		timer = 0.0f;
		decided_extension_factor = Random.Range (0.0f, random_extension_factor);
	}
}
