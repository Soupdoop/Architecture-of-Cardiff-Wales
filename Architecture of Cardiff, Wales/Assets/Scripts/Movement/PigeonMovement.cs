using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigeonMovement : BasicMovement {

	bool facing = false; // true == right, false == left
	public float flapStrength = 1.0f;
	public Rigidbody2D rb;

	public SpriteRenderer sprite;

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

		facing = false;
		sprite.flipX = facing;
	}

	override protected void DoRightAction() {
		#if DEBUG 
		Debug.Log("Pigeon Right!");
		#endif

		facing = true;
		sprite.flipX = facing;
	}

	override protected void DoSpecialAction() {
		#if DEBUG 
		Debug.Log("Pigeon Special!");
		#endif

		if (facing) {
			rb.AddForce((2*Vector2.up + Vector2.right) * flapStrength);
		} else {
			rb.AddForce((2*Vector2.up + Vector2.left) * flapStrength);
		}
	}

	override protected void DoNeutralAction() {
		
	}
}
