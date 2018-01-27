using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Activatable : MonoBehaviour {

	public bool activated = false;

	public bool Activate() {
		activated = true;
		return activated;
	}

	public bool Deactivate() {
		activated = false;
		return activated;
	}
}
