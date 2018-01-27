using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : BasicMovement {

	public float movementStrength = 1.0f;
	public float topSpeed;
	public float steerSpeed;
	public float decelStrength;
	private float currentSpeed;
	private float tolerance = 0.05f;
	public Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		#if DEBUG 
		Debug.Log("This is a car starting.");
		#endif
		currentSpeed = 0;
		if (rb == null) {
			rb = GetComponent<Rigidbody2D>();
		}
	}

	override protected void UpdateFields() {
		rb.velocity = (Vector2)transform.right.normalized * currentSpeed; //always move toward heading
	}

	override protected void DoUpAction() {
		#if DEBUG 
		Debug.Log("Car Up!");
		#endif

		if (rb.velocity.magnitude < topSpeed) {
			currentSpeed += movementStrength * Time.deltaTime;
		}
	}

	override protected void DoDownAction() {
		#if DEBUG 
		Debug.Log("Car Down!");
		#endif
		if (rb.velocity.magnitude < topSpeed + tolerance) {
			currentSpeed -= movementStrength * Time.deltaTime;
		}
	}

	override protected void DoLeftAction() {
		#if DEBUG 
		Debug.Log("Car Left!");
		#endif

		rb.AddTorque (steerSpeed);
	}

	override protected void DoRightAction() {
		#if DEBUG 
		Debug.Log("Car Right!");
		#endif

		rb.AddTorque (-steerSpeed);
	}

	override protected void DoSpecialAction() {
		#if DEBUG 
		Debug.Log("Car Special!");
		#endif

		//		rb.AddForce(rb.velocity * movementStrength);
	}

	override protected void DoNeutralAction() {
		rb.AddForce(decelStrength*-rb.velocity);
	}
}
