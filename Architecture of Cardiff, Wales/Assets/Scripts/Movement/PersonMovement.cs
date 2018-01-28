using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonMovement : BasicMovement {

	public float movementSpeed = 1.0f;
	public float jumpStrength = 1.0f;
	public int jumpRandMin = 10;
	public int jumpRandMax = 10;
	public Rigidbody2D rb;
	public SpriteRenderer sprite;

	private float jumpCD = 0.0f;

	public Animator anim;

	// Use this for initialization
	void Start () {
		#if DEBUG 
		Debug.Log("This is a person starting.");
		#endif
		if (rb == null) {
			rb = GetComponent<Rigidbody2D>();
		}
		if (sprite == null) {
			sprite = GetComponent<SpriteRenderer>();
		}
		if (anim == null) {
			anim = GetComponent<Animator>();
		}
	}

	override protected void UpdateFields() {
		if (jumpCD > 0.0f) jumpCD -= Time.deltaTime;
	}

	override protected void DoUpAction() {
		#if DEBUG 
		//Debug.Log("Person Up!");
		#endif

		if (jumpCD <= 0.0f && checkOnGround()) {
			#if DEBUG
			Debug.Log("Person Jumping!");
			#endif
			int randInt = Random.Range(jumpRandMin,jumpRandMax);
			rb.AddForce(Vector2.up * (jumpStrength * randInt/jumpRandMax));
			jumpCD = 0.5f;
		}
	}

	override protected void DoDownAction() {
		#if DEBUG 
		Debug.Log("Person Down!");
		#endif

	}

	override protected void DoLeftAction() {
		#if DEBUG 
		Debug.Log("Person Left!");
		#endif

		if (!sprite.flipX) {
			sprite.flipX = true;
		}

		anim.SetBool("Wobble", true);

		Vector2 curVel = rb.velocity;
		curVel = new Vector2(-movementSpeed, curVel.y);

		rb.velocity = curVel;
	}

	override protected void DoRightAction() {
		#if DEBUG 
		Debug.Log("Person Right!");
		#endif
		if (sprite.flipX) {
			sprite.flipX = false;
		}

		anim.SetBool("Wobble", true);

		Vector2 curVel = rb.velocity;
		curVel = new Vector2(movementSpeed, curVel.y);
		rb.velocity = curVel;
	}

	override protected void DoSpecialAction() {
		#if DEBUG 
		Debug.Log("Person Special!");
		#endif

		DoUpAction();
	}

	override protected void DoNeutralAction() {
		
		anim.SetBool("Wobble", false);

		Vector2 curVel = rb.velocity;
		curVel = new Vector2(0.0f, curVel.y);
		rb.velocity = curVel;
	}
}
