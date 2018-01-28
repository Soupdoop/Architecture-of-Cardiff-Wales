using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainMovement : BasicMovement {

    public float maxSpeed = 100;
    public float movementStrength = 1.0f;
    public float steerSpeed;
    public Rigidbody2D rb;

    private Vector2 facing;

    // Use this for initialization
    void Start() {
        #if DEBUG
        Debug.Log("This is a train starting.");
        #endif
        if (rb == null) {
            rb = GetComponent<Rigidbody2D>();
        }
        facing = Vector2.right;
    }

    override protected void UpdateFields() {
        if (Vector2.Angle(transform.right, facing) > 120) {
            Vector3 scale = transform.localScale;
            transform.localScale = new Vector3(scale.x, -1 * scale.y, scale.z);
            facing *= -1;
        }
    }

    override protected void DoUpAction() {
        #if DEBUG
        Debug.Log("Train Up!");
        #endif
        if (rb.velocity.magnitude < maxSpeed)
            rb.AddForce((Vector2)transform.right * movementStrength);
    }

    override protected void DoDownAction() {
        #if DEBUG
        Debug.Log("Train Down!");
        #endif
        if (rb.velocity.magnitude < maxSpeed)
            rb.AddForce((Vector2)transform.right * -movementStrength);
    }

    override protected void DoLeftAction() {
        #if DEBUG
        Debug.Log("Train Left!");
        #endif

        //rb.AddTorque(steerSpeed);
    }

    override protected void DoRightAction() {
        #if DEBUG
        Debug.Log("Train Right!");
        #endif

        //rb.AddTorque(-steerSpeed);
    }

    override protected void DoSpecialAction() {
        #if DEBUG
        Debug.Log("Spaceship Special!");
        #endif

        //rb.AddForce(rb.velocity * movementStrength);
    }

    override protected void DoNeutralAction() {
        rb.AddForce(-1*rb.velocity); //no deceleration for spaceships
    }
}
