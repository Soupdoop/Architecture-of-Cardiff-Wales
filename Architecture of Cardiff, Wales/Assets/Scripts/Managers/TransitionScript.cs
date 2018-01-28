using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionScript : MonoBehaviour {

    public GameManager gm;

    public void EndAnimationEvent() {
        gm.NextLevel();
    }
}
