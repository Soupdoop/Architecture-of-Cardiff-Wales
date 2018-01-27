using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseTarget : MonoBehaviour {

	public string targetTag = "Infected";

	public Sprite chasingSprite;
	public Sprite idleSprite;

	public float chaseSpeed = 1.0f;
	public float maxDist = 1.0f;

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
			Debug.Log("Looking at " + go.name + " at distance of " + dist);
			if (dist > maxDist) continue;
			Debug.Log("Within max distance");
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
			sprite.flipX = minObj.transform.position.x > transform.position.x;
			transform.localRotation = Quaternion.FromToRotation(transform.position, minObj.transform.position);
		}
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.CompareTag("Infected")) {
			Destroy(coll.gameObject);
		}
	}
}
