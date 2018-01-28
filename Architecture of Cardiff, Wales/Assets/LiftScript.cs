using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftScript : MonoBehaviour {

    public Collider2D thisColl;
    //private BoxCollider2D trigger;

    private void Start() {

        if (thisColl == null)
            thisColl = gameObject.GetComponent<Collider2D>();

        /*
        trigger = gameObject.AddComponent<BoxCollider2D>();
        trigger.isTrigger = true;

        Vector2[] extremePoints = {
            transform.TransformPoint(new Vector2(0, thisColl.bounds.min.y + thisColl.offset.y)),
            transform.TransformPoint(new Vector2(thisColl.bounds.min.x + thisColl.offset.x, 0)),
            transform.TransformPoint(new Vector2(thisColl.bounds.max.x + thisColl.offset.x, 0))
        };
        /*
        Vector2 boMost = new Vector2(0, thisColl.bounds.min.y + thisColl.offset.y);
        Vector2 leMost = new Vector2(thisColl.bounds.min.x + thisColl.offset.x, 0);
        Vector2 riMost = new Vector2(thisColl.bounds.max.x + thisColl.offset.x, 0);

        Vector2 wBoMost = transform.TransformPoint(boMost);
        Vector2 wLeMost = transform.TransformPoint(leMost);
        Vector2 wRiMost = transform.TransformPoint(riMost);

        Vector2 lowPoint = new Vector2(0, float.MaxValue);
        foreach (Vector2 point in extremePoints)
            if (point.y < lowPoint.y)
                lowPoint = point;

        Vector2 relLowPoint = transform.InverseTransformPoint(lowPoint);

        trigger.offset = relLowPoint;
        trigger.size = new Vector2(1, 1);
        */
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.CompareTag("Infected")) {
            ContactPoint2D[] contactPoints = new ContactPoint2D[1];
            collision.GetContacts(contactPoints);
            ContactPoint2D contactPoint = contactPoints[0];
            Vector2 point = contactPoint.point;

            float angle = (Mathf.Abs(transform.rotation.z) % 180);
            float size = (angle > 45 && angle < 135) ? thisColl.bounds.extents.x : thisColl.bounds.extents.y;
            size *= 0.75f;

            float test = transform.position.y - size;

            if (test >= point.y)
                Stick(collision.collider);
        }
    }

    void Stick(Collider2D other) {
        FixedJoint2D stickPoint = gameObject.AddComponent<FixedJoint2D>();
        stickPoint.connectedBody = other.attachedRigidbody;
    }
}
