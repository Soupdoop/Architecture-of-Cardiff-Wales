using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boogalooMove : MonoBehaviour {

    private Vector3 target;
	private Vector3 start;
    private float smoothSpeed = 1f;

	float timer;

    private void Start() {
		start = this.transform.position;
        target = new Vector3(0, 20, 0);
        Debug.Log(target);
		timer = 0;
    }

    // Update is called once per frame
    void FixedUpdate() {
		if(timer < smoothSpeed){
			timer += Time.deltaTime;
			Vector3 temp = Vector3.Lerp (start, target, timer / smoothSpeed);
			temp.z = start.z;
			this.gameObject.transform.position = temp;
		}
    }
}
