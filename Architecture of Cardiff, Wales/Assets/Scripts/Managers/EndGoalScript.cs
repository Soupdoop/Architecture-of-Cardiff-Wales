using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Collider2D))]
public class EndGoalScript : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("SOMEBODY TOUCHA THE SPAGHET");
    }
}
