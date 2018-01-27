using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_at_speed : MonoBehaviour {

	public float speed_per_second_x;
	public float speed_per_second_y;
	public float speed_per_second_z;

	public float random_speed_per_second_x;
	public float random_speed_per_second_y;
	public float random_speed_per_second_z;

	void Start ()
	{
		speed_per_second_x += Random.Range (0, random_speed_per_second_x);
		speed_per_second_y += Random.Range (0, random_speed_per_second_y);
		speed_per_second_z += Random.Range (0, random_speed_per_second_z);
	}

	// Update is called once per frame
	void Update () {
		float dt = Time.deltaTime;
		this.gameObject.transform.Translate (speed_per_second_x * dt, speed_per_second_y * dt, speed_per_second_z * dt);
	}
}
