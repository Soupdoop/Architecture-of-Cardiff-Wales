using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GalaxyControl : Activatable {

    public Activatable armadaPrefab;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override bool Activate()
    {
        base.Activate();
        Activatable armada = Instantiate(armadaPrefab, transform.position, Quaternion.identity);
        armada.Activate();
        return activated;
    }

}
