using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Activatable : MonoBehaviour {

	protected bool activated = true;

	public bool Activate() {
		activated = true;
		return activated;
	}

	public bool Deactivate() {
		activated = false;
		return activated;
	}
}
