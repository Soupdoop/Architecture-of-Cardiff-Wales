using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boogalooMove : MonoBehaviour {

    private Vector3 target;
    private float smoothSpeed = 5f;

    private void Start() {
        target = new Vector3(450, 400, 0);
        Debug.Log(target);
    }

    // Update is called once per frame
    void FixedUpdate() {
        transform.position = Vector3.MoveTowards(transform.position, target, smoothSpeed);
    }
}
