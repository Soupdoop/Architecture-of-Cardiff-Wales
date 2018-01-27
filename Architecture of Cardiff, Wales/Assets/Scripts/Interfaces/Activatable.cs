using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Activatable : MonoBehaviour {

	protected bool activated = true;

	bool Activate() {
		activated = true;
		return activated;
	}

	bool Deactivate() {
		activated = false;
		return activated;
	}
}
