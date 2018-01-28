using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobChaseTarget : MonoBehaviour {

    public string targetTag = "Infected";

    public float chaseSpeed = 1.0f;
    public float maxDist = 1.0f;

    public Rigidbody2D rb;
    Animator anim;

    // Use this for initialization
    void Start () {
        if (rb == null) rb = GetComponent<Rigidbody2D>();
        if (anim == null)
            anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        GameObject[] targets = GameObject.FindGameObjectsWithTag(targetTag);
        float minDistance = float.MaxValue;
        GameObject minObj = null;
        foreach (GameObject go in targets) {
            float dist = Vector2.Distance(transform.position, go.transform.position);
            //Debug.Log("Looking at " + go.name + " at distance of " + dist);
            Activatable infected = go.GetComponent<Activatable>();
            if (infected == null || !infected.activated || dist > maxDist) continue;
            //Debug.Log("Within max distance");
            if (dist < minDistance) {
                minDistance = dist;
                minObj = go;
            }
        }
        if (minObj == null) {
            rb.AddForce(-chaseSpeed * rb.velocity);
        }
        else {
            anim.SetBool("Wobble", true);
            // rb.AddForce((minObj.transform.position - transform.position).normalized * chaseSpeed);
            transform.position += (minObj.transform.position - transform.position).normalized * chaseSpeed;
            // transform.localRotation = Quaternion.FromToRotation(transform.position, minObj.transform.position);
        }
    }

    void OnCollisionEnter2D(Collision2D coll) {
        if (coll.gameObject.CompareTag("Infected")) {
            Destroy(coll.gameObject);
        }
    }
}
