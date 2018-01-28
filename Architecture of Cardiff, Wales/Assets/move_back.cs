using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_back : MonoBehaviour {

	Vector3 start;
	public Collider2D trigger;

	// Use this for initialization
	void Start () {
		start = this.gameObject.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll == trigger) 
		{
			this.gameObject.transform.position = start;
		}
	}
}
