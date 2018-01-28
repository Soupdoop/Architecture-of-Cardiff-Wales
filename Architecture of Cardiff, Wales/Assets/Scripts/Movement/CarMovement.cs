using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : BasicMovement {

	public float movementStrength = 1.0f;
	public float topSpeed;
	public float steerSpeed;
	public float decelStrength;
	private float currentSpeed;
	private float tolerance = 0.05f;
    private float xCompLastTime;
	public Rigidbody2D rb;

    // public AudioSource audio;

    private Vector2 facing;

    // Use this for initialization
    void Start () {
		#if DEBUG 
		Debug.Log("This is a car starting.");
		#endif
		currentSpeed = 0;
        xCompLastTime = transform.right.x;
		if (rb == null) {
			rb = GetComponent<Rigidbody2D>();
		}
        facing = Vector2.right;

        if (!audio) {
            audio = gameObject.GetComponent<AudioSource>();
        }
    }

	override protected void UpdateFields() {

        if (Vector2.Angle(transform.right, facing) > 120) {
            facing *= -1;
        }

        rb.velocity = (Vector2)transform.right.normalized * currentSpeed; //always move toward heading
        //This flips the scale of the gameobject
        if (Mathf.Sign(xCompLastTime) != Mathf.Sign(transform.right.x)) {
            Vector3 scale = transform.localScale;
            transform.localScale = new Vector3(scale.x, -1*scale.y, scale.z);
        }
        xCompLastTime = transform.right.x;
        /*
        if (activated) {
            audio.mute = false;
        }
        else
            audio.mute = true;
        */
    }

	override protected void DoUpAction() {
		#if DEBUG 
		Debug.Log("Car Up!");
		#endif

		if (rb.velocity.magnitude < topSpeed) {
			currentSpeed += movementStrength * Time.deltaTime;
		}
	}

	override protected void DoDownAction() {
		#if DEBUG 
		Debug.Log("Car Down!");
		#endif
		if (rb.velocity.magnitude < topSpeed + tolerance) {
			currentSpeed -= movementStrength * Time.deltaTime;
		}
	}

	override protected void DoLeftAction() {
		#if DEBUG 
		Debug.Log("Car Left!");
		#endif

		rb.AddTorque (steerSpeed);
	}

	override protected void DoRightAction() {
		#if DEBUG 
		Debug.Log("Car Right!");
		#endif

		rb.AddTorque (-steerSpeed);
	}

	override protected void DoSpecialAction() {
		#if DEBUG 
		Debug.Log("Car Special!");
		#endif

		//		rb.AddForce(rb.velocity * movementStrength);
	}

	override protected void DoNeutralAction() {
		rb.AddForce(decelStrength*-rb.velocity);
	}
}
