using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneMovement : BasicMovement {

	public float movementStrength = 1.0f;
	public float topSpeed;
	public float steerSpeed;
	public float decelStrength;

	public float minSize = 1.0f;
	public float maxSize = 2.0f;

	private float currentSpeed;
	private float currentRotation;
	private float tolerance = 0.05f;
	public Rigidbody2D rb;
	public Collider2D collider;



	// Use this for initialization
	void Start () {
		#if DEBUG 
		Debug.Log("This is a plane starting.");
		#endif
		currentSpeed = 0.0f;
		currentRotation = transform.localRotation.eulerAngles.z;
		if (rb == null) {
			rb = GetComponent<Rigidbody2D>();
		}
	}

	override protected void UpdateFields() {
		rb.velocity = (Vector2)transform.right.normalized * currentSpeed; //always move toward heading
		float speedPercentage = rb.velocity.magnitude/topSpeed;
		float curSize = Mathf.Lerp(minSize, maxSize, speedPercentage);
		transform.localScale = new Vector3(curSize, curSize, curSize);
		collider.enabled = rb.velocity.magnitude < tolerance;
		transform.localRotation = Quaternion.Euler(new Vector3(transform.localRotation.eulerAngles.x, transform.localRotation.eulerAngles.y, currentRotation));
	}

	override protected void DoUpAction() {
		#if DEBUG 
		Debug.Log("Plane Up!");
		#endif

		if (currentSpeed < topSpeed) {
			currentSpeed += movementStrength * Time.deltaTime;
		}
	}

	override protected void DoDownAction() {
		#if DEBUG 
		Debug.Log("Plane Down!");
		#endif
		if (currentSpeed > 0) {
			currentSpeed -= movementStrength * Time.deltaTime;
		}
	}

	override protected void DoLeftAction() {
		#if DEBUG 
		Debug.Log("Plane Left!");
		#endif

		currentRotation += steerSpeed;
	}

	override protected void DoRightAction() {
		#if DEBUG 
		Debug.Log("Plane Right!");
		#endif

		currentRotation -= steerSpeed;
	}

	override protected void DoSpecialAction() {
		#if DEBUG 
		Debug.Log("Plane Special!");
		#endif

		//		rb.AddForce(rb.velocity * movementStrength);
	}

	override protected void DoNeutralAction() {
		if (currentSpeed > 0) currentSpeed -= decelStrength * Time.deltaTime;
	}
}
