﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigeonMovement : BasicMovement {

	public bool facing = false; // true == right, false == left
	public float flapStrength = 1.0f;
	public float movementSpeed = 1.0f;
	public int speedRandomMinimum;
	public int speedRandomMaximum;
	public Rigidbody2D rb;

	public SpriteRenderer sprite;

    public int fatSize = 1;

	public Animator anim;

	// Use this for initialization
	void Start () {
		#if DEBUG 
		Debug.Log("This is a pigeon starting.");
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
		movementSpeed *= (float)Random.Range(speedRandomMinimum, speedRandomMaximum)/speedRandomMaximum;

        rb.mass = fatSize;
        transform.localScale *= fatSize;
	}
	
	override protected void UpdateFields() {

	}

	override protected void DoUpAction() {
		#if DEBUG 
		//Debug.Log("Pigeon Up!");
		#endif
	}

	override protected void DoDownAction() {
		#if DEBUG 
		Debug.Log("Pigeon Down!");
		#endif

	}

	override protected void DoLeftAction() {
		#if DEBUG 
		Debug.Log("Pigeon Left!");
		#endif

		anim.SetBool("Wobble", true);

		rb.AddForce(Vector2.left * movementSpeed);

		facing = false;
        Vector2 scale = transform.localScale;
        scale.x = 1 * fatSize;
		transform.localScale = scale;
	}

	override protected void DoRightAction() {
		#if DEBUG 
		Debug.Log("Pigeon Right!");
		#endif

		anim.SetBool("Wobble", true);

		rb.AddForce(Vector2.right * movementSpeed);

		facing = true;
        Vector2 scale = transform.localScale;
        scale.x = -1 * fatSize;
        transform.localScale = scale;
    }

    override protected void DoSpecialAction() {
		#if DEBUG 
		Debug.Log("Pigeon Special!");
        #endif
        audio.PlayOneShot(audio.clip);
		if (rb.velocity.y <= 0.0f){
			anim.SetTrigger("Flap");

			if (facing) {
				rb.AddForce((2*Vector2.up/* + Vector2.right*/) * flapStrength);
			} else {
				rb.AddForce((2*Vector2.up/* + Vector2.left*/) * flapStrength);
			}
		}
	}

	override protected void DoNeutralAction() {
		anim.SetBool("Wobble", false);
	}
}
