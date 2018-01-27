using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BasicMovement : Activatable {

	public float deadzone = 0.1f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (activated) {
			float horiz = Input.GetAxis("Horizontal");
			float vert = Input.GetAxis("Vertical");

			if (Mathf.Abs(horiz) > deadzone){
				if (horiz < 0.0f) {
					DoLeftAction();
				} else if (horiz > 0.0f) {
					DoRightAction();
				}
			}

			if (Mathf.Abs(vert) > deadzone){
				if (vert < 0.0f) {
					DoDownAction();
				} else if (vert > 0.0f) {
					DoUpAction();
				}
			}

			if (Input.GetButtonDown("Special")) {
				DoSpecialAction();
			}
		}
	}

	abstract protected void DoUpAction();

	abstract protected void DoDownAction();

	abstract protected void DoLeftAction();

	abstract protected void DoRightAction();

	abstract protected void DoSpecialAction();
}
