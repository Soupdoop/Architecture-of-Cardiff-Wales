using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatMovement : BasicMovement {

	public float movementSpeed = 1.0f;
	public float jumpStrength = 1.0f;
	public Rigidbody2D rb;

	private float jumpCD = 0.0f;

	// Use this for initialization
	void Start () {
		#if DEBUG 
		Debug.Log("This is a rat starting.");
		#endif
		if (rb == null) {
			rb = GetComponent<Rigidbody2D>();
		}
	}

	override protected void UpdateFields() {
		if (jumpCD > 0.0f) jumpCD -= Time.deltaTime;
	}

	override protected void DoUpAction() {
		#if DEBUG 
		//Debug.Log("Rat Up!");
		#endif

		if (jumpCD <= 0.0f && checkOnGround()) {
			#if DEBUG
			Debug.Log("Rat Jumping!");
			#endif
			rb.AddForce(Vector2.up * jumpStrength);
			jumpCD = 0.5f;
		}
	}

	override protected void DoDownAction() {
		#if DEBUG 
		Debug.Log("Rat Down!");
		#endif

	}

	override protected void DoLeftAction() {
		#if DEBUG 
		Debug.Log("Rat Left!");
		#endif

		Vector2 curVel = rb.velocity;
		curVel = new Vector2(-movementSpeed, curVel.y);

		rb.velocity = curVel;
	}

	override protected void DoRightAction() {
		#if DEBUG 
		Debug.Log("Rat Right!");
		#endif
		Vector2 curVel = rb.velocity;
		curVel = new Vector2(movementSpeed, curVel.y);
		rb.velocity = curVel;
	}

	override protected void DoSpecialAction() {
		#if DEBUG 
		Debug.Log("Rat Special!");
		#endif

		DoUpAction();
	}

	override protected void DoNeutralAction() {
		Vector2 curVel = rb.velocity;
		curVel = new Vector2(0.0f, curVel.y);
		rb.velocity = curVel;
	}
}
