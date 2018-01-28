using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Activatable : MonoBehaviour {

	public bool activated = false;
	public bool hasBeenActivated = false;

	public virtual bool Activate() {
		activated = true;
		hasBeenActivated = true;
		return activated;
	}

	public virtual bool Deactivate() {
		activated = false;
		return activated;
	}
}
