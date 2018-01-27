using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraFollow : MonoBehaviour {

	public GameObject followed;
	public float size;

	// Use this for initialization
	void Start () {
		if (followed == null) {
			followed = gameObject;
		}
		gameObject.GetComponent<Camera>().orthographic = true;
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.position = new Vector3(followed.transform.position.x,followed.transform.position.y,gameObject.transform.position.z);
		gameObject.GetComponent<Camera>().orthographicSize = size;
	}

	public void ChangeFollowed(GameObject go) {
		followed = go;
	}

	public void ChangeSize(float sz) {
		size = sz;
	}
}
