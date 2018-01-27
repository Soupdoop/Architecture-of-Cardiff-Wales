#define DEBUG

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GermMovement : BasicMovement {

	public float movementStrength = 1.0f;
	public Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		#if DEBUG 
		Debug.Log("This is a germ starting.");
		#endif
		if (rb == null) {
			rb = GetComponent<Rigidbody2D>();
		}
	}

	override protected void UpdateFields() {

	}

	override protected void DoUpAction() {
		#if DEBUG 
		Debug.Log("Germ Up!");
		#endif

		rb.AddForce(Vector2.up * movementStrength);
	}

	override protected void DoDownAction() {
		#if DEBUG 
		Debug.Log("Germ Down!");
		#endif

		rb.AddForce(Vector2.down * movementStrength);
	}

	override protected void DoLeftAction() {
		#if DEBUG 
		Debug.Log("Germ Left!");
		#endif

		rb.AddForce(Vector2.left * movementStrength);
	}

	override protected void DoRightAction() {
		#if DEBUG 
		Debug.Log("Germ Right!");
		#endif

		rb.AddForce(Vector2.right * movementStrength);
	}

	override protected void DoSpecialAction() {
		#if DEBUG 
		Debug.Log("Germ Special!");
		#endif

		rb.AddForce(rb.velocity * movementStrength);
	}

	override protected void DoNeutralAction() {
		rb.AddForce(-1*rb.velocity);
	}

}
