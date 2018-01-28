using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseTarget : MonoBehaviour {

	public string targetTag = "Infected";

	public Sprite chasingSprite;
	public Sprite idleSprite;

	public float chaseSpeed = 1.0f;
	public float maxDist = 1.0f;
    public bool origFacing = false; // true == right, false == left

    public Rigidbody2D rb;
	public SpriteRenderer sprite;

	// Use this for initialization
	void Start () {
		if (rb == null) rb = GetComponent<Rigidbody2D>();
		if (sprite == null) sprite = GetComponent<SpriteRenderer>();
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
			sprite.sprite = idleSprite;
			rb.AddForce(-chaseSpeed*rb.velocity);
		} else {
			sprite.sprite = chasingSprite;
			rb.AddForce((minObj.transform.position - transform.position).normalized * chaseSpeed);
			bool isRight = minObj.transform.position.x > transform.position.x;
            sprite.flipX = isRight ^ origFacing;
            Vector2 rotFrom = isRight ? Vector2.right : Vector2.left;
            Vector2 rotTo = minObj.transform.position - transform.position;
            transform.localRotation = Quaternion.FromToRotation(rotFrom, rotTo);
		}
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.CompareTag("Infected")) {
			Destroy(coll.gameObject);
		}
	}
}
