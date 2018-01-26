using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float friction;

	public float speed;

	public float jump;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		float newVerticalVelocity = 0;
		if(Input.GetAxis("Vertical") > 0 && gameObject.GetComponent<Rigidbody2D>().velocity.y == 0) {
			newVerticalVelocity = jump;
		} else {
			newVerticalVelocity = gameObject.GetComponent<Rigidbody2D>().velocity.y;
		}
		float newHorizontalVelocity = Input.GetAxis("Horizontal") * speed;
		gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(newHorizontalVelocity, newVerticalVelocity);
		//gameObject.GetComponent<Rigidbody2D>().velocity *= (1 - friction);
	}
}
