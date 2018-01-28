using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticMovement : BasicMovement {


	public Rigidbody2D rb;


	// Use this for initialization
	void Start () {
		if (rb == null) {
			rb = GetComponent<Rigidbody2D>();
		}
	}

	override protected void UpdateFields() {
		//Door dont fucking moove
	}

	override protected void DoUpAction() {
		//DOOR DONT MOVE
	}

	override protected void DoDownAction() {
		//DOOR STAY STIKL:LL
	}

	override protected void DoLeftAction() {
		//Is Door
	}

	override protected void DoRightAction() {
		//Still Door
	}

	override protected void DoSpecialAction() {
		//MaybeCity
	}

	override protected void DoNeutralAction() {
		//Consider....
	}
}
