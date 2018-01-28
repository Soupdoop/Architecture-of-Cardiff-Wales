using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftScript : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D collision) {
        Collider2D other = collision.collider;
        if (other.CompareTag("Infected")) {
            Stick(other);
        }
    }

    void Stick(Collider2D other) {
        FixedJoint2D stickPoint = transform.parent.gameObject.AddComponent<FixedJoint2D>();
        stickPoint.connectedBody = other.attachedRigidbody;
    }
}
