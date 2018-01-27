using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spin_at_speed : MonoBehaviour {

	public float speed_per_second;

	Vector3 z = Vector3.forward;
	
	// Update is called once per frame
	void Update () {
		this.gameObject.transform.Rotate (z, speed_per_second * Time.deltaTime);
	}
}
