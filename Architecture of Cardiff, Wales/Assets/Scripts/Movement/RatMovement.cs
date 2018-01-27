#define DEBUG

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatMovement : BasicMovement {

	public float movementSpeed = 1.0f;
	public float jumpStrength = 1.0f;
	public Rigidbody2D rb;

	bool onGround = true;

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

	}

	override protected void DoUpAction() {
		#if DEBUG 
		//Debug.Log("Rat Up!");
		#endif

		if (onGround) {
			#if DEBUG
			Debug.Log("Rat Jumping!");
			#endif
			rb.AddForce(Vector2.up * jumpStrength);
			onGround = false;
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

	void OnCollisionEnter2D(Collision2D coll) {
		#if DEBUG
		Debug.Log("Collision Entered!");
		#endif
		Collider2D groundColl = coll.gameObject.GetComponent<Collider2D>();
		Collider2D thisColl = GetComponent<Collider2D>();

		Vector3 collMax = groundColl.bounds.max;
		Vector3 thisMin = thisColl.bounds.min;

		bool withinBounds = true;

		#if DEBUG
		Debug.Log("This Min.y: " + thisMin.y);
		Debug.Log("Coll Max.y: " + collMax.y);
		#endif

		if (coll.gameObject.transform.position.y > transform.position.y) withinBounds = false;
		if (thisColl.bounds.min.x > groundColl.bounds.max.x || thisColl.bounds.max.x < groundColl.bounds.min.x) withinBounds = false;

		if (withinBounds) onGround = true;
	}
}
