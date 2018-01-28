using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour {

    public List<Transform> targets = new List<Transform>();

    private Vector3 offset;

    private float smoothSpeed = 0.01f;

    private Vector3 avgTarget;

    private void Start() {
        offset = transform.position;
        
    }

    // Update is called once per frame
    /*void FixedUpdate() {
        if ((player.position - transform.position).magnitude > 5) {
            Vector3 target = player.position + offset;
            Vector3 smoothTarget = Vector3.Lerp(transform.position, target, smoothSpeed);
            transform.position = smoothTarget;
        }
    }
    */
}
