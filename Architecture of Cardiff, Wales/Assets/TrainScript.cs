using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainScript : MonoBehaviour {

    public float maxSpeed;
    public Rigidbody2D body;

    //True if you want to use up/down, false if you want to use left/right
    public bool Vertical = true;

    private string trainType;

    private void Start() {
        trainType = (Vertical) ? "Vertical" : "Horizontal";
        body = gameObject.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {
        float s = Input.GetAxis(trainType);
        if (body.velocity.magnitude < maxSpeed) {
            body.AddRelativeForce(Vector2.right * s * 10);
        }
    }

    public void ChangeType(bool vertical) {
        trainType = (vertical) ? "Vertical" : "Horizontal";
    }
}
