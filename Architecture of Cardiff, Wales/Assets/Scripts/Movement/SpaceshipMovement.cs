#undef DEBUG
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipMovement : BasicMovement {

	public float movementStrength = 1.0f;
	public float steerSpeed;
	public Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		#if DEBUG 
		Debug.Log("This is a spaceship starting.");
		#endif
		if (rb == null) {
			rb = GetComponent<Rigidbody2D>();
		}
	}

	override protected void UpdateFields() {
	}

	override protected void DoUpAction() {
		#if DEBUG 
		Debug.Log("Spaceship Up!");
		#endif

		rb.AddForce((Vector2)transform.right * movementStrength);
	}

	override protected void DoDownAction() {
		#if DEBUG 
		Debug.Log("Spaceship Down!");
		#endif

		rb.AddForce ((Vector2)transform.right * -movementStrength);
	}

	override protected void DoLeftAction() {
		#if DEBUG 
		Debug.Log("Spaceship Left!");
		#endif

		rb.AddTorque (steerSpeed);
	}

	override protected void DoRightAction() {
		#if DEBUG 
		Debug.Log("Spaceship Right!");
		#endif

		rb.AddTorque (-steerSpeed);
	}

	override protected void DoSpecialAction() {
		#if DEBUG 
		Debug.Log("Spaceship Special!");
		#endif

//		rb.AddForce(rb.velocity * movementStrength);
	}

	override protected void DoNeutralAction() {
//		rb.AddForce(-1*rb.velocity); //no deceleration for spaceships
	}
}
