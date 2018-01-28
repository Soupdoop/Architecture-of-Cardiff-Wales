using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroids : MonoBehaviour {

	public Vector2 init_velocity;
	public Rigidbody2D rb;
	public float collisionMultiplier = 1.0f;

	// Use this for initialization
	void Start () {
		if (rb == null) rb = GetComponent<Rigidbody2D>();
		rb.velocity = init_velocity;
	}
	
	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.collider.attachedRigidbody)
			coll.collider.attachedRigidbody.AddForce(-collisionMultiplier*coll.relativeVelocity);
	}
}
