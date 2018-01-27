using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BasicMovement : Activatable {

	public float deadzone = 0.1f;
	
	// Update is called once per frame
	void Update () {
		UpdateFields();
		if (activated) {
			float horiz = Input.GetAxis("Horizontal");
			float vert = Input.GetAxis("Vertical");

			bool action = false;

			if (Mathf.Abs(horiz) > deadzone){
				action = true;
				if (horiz < 0.0f) {
					DoLeftAction();
				} else if (horiz > 0.0f) {
					DoRightAction();
				}
			}

			if (Mathf.Abs(vert) > deadzone){
				action = true;
				if (vert < 0.0f) {
					DoDownAction();
				} else if (vert > 0.0f) {
					DoUpAction();
				}
			}

			if (Input.GetButtonDown("Special")) {
				action = true;
				DoSpecialAction();
			}

			if (!action) DoNeutralAction();
		}
	}

	abstract protected void UpdateFields();

	abstract protected void DoUpAction();

	abstract protected void DoDownAction();

	abstract protected void DoLeftAction();

	abstract protected void DoRightAction();

	abstract protected void DoSpecialAction();

	abstract protected void DoNeutralAction();
}
