using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuStart : MonoBehaviour {

    public GameManager gm;

	// Use this for initialization
	void Start () {
        gm.DisablePause(true);
	}
}
