using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobMovement : BasicMovement {

	private Vector2 currentVelocity;
	public float movementSpeed = 1.0f;
	public Rigidbody2D rb;

	public Animator anim;

	public int speedRandomMinimum;
	public int speedRandomMaximum;

	// Use this for initialization
	void Start () {
		#if DEBUG 
		Debug.Log("This is a germ starting.");
		#endif
		currentVelocity = Vector2.zero;
		if (rb == null) {
			rb = GetComponent<Rigidbody2D>();
		}
		if (anim == null) {
			anim = GetComponent<Animator>();
		}
		movementSpeed *= (float)Random.Range(speedRandomMinimum, speedRandomMaximum)/speedRandomMaximum;
	}

	override protected void UpdateFields() {
		rb.velocity = currentVelocity;
		currentVelocity = Vector2.zero;
	}

	override protected void DoUpAction() {
		#if DEBUG 
		Debug.Log("Germ Up!");
		#endif
		anim.SetBool("Wobble", true);
		currentVelocity.y = movementSpeed;
	}

	override protected void DoDownAction() {
		#if DEBUG 
		Debug.Log("Germ Down!");
		#endif
		anim.SetBool("Wobble", true);
		currentVelocity.y = -movementSpeed;
	}

	override protected void DoLeftAction() {
		#if DEBUG 
		Debug.Log("Germ Left!");
		#endif
		anim.SetBool("Wobble", true);
		currentVelocity.x = -movementSpeed;
	}

	override protected void DoRightAction() {
		#if DEBUG 
		Debug.Log("Germ Right!");
		#endif
		anim.SetBool("Wobble", true);
		currentVelocity.x = movementSpeed;
	}

	override protected void DoSpecialAction() {
		#if DEBUG 
		Debug.Log("Mob Special!");
		#endif
	}

	override protected void DoNeutralAction() {
		anim.SetBool("Wobble", false);
		currentVelocity = Vector2.zero;
	}
}
