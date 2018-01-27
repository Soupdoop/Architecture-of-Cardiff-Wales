using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BasicMovement : Activatable {

	public float deadzone = 0.1f;

	public LayerMask noJump;
	
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

	protected bool checkOnGround() {
		Collider2D thisColl = GetComponent<Collider2D>();

		Vector2 size = (Vector2)(thisColl.bounds.size);
		Vector3 worldPos = thisColl.bounds.center;

		float bottom = worldPos.y - (size.y / 2f);
		float left = worldPos.x - (size.x / 2f);
		float right = worldPos.x + (size.x / 2f);

		int layerMask = ~noJump.value;
		float rayLength = Mathf.Max(size.y/100.0f, 0.05f);

		RaycastHit2D blray = Physics2D.Raycast(new Vector2(left, bottom), Vector2.down,rayLength, layerMask);
		RaycastHit2D brray = Physics2D.Raycast(new Vector2(right, bottom), Vector2.down, rayLength, layerMask);

		return blray.collider != null || brray.collider != null;
	}

	void OnDrawGizmos() {
		Collider2D thisColl = GetComponent<Collider2D>();

		Vector2 size = (Vector2)(thisColl.bounds.size);
		Vector3 worldPos = thisColl.bounds.center;

		float bottom = worldPos.y - (size.y / 2f);
		float left = worldPos.x - (size.x / 2f);
		float right = worldPos.x + (size.x / 2f);

		float rayLength = Mathf.Max(size.y/100.0f, 0.05f);

		Gizmos.color = Color.red;
		Gizmos.DrawLine(new Vector2(left, bottom), new Vector2(right, bottom));
		Gizmos.DrawLine(new Vector2(left, bottom), new Vector2(left, bottom) + (Vector2.down*rayLength));
	}
}
