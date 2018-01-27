using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Activatable))]
public class Infection : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (GetComponent<Activatable>().activated)
        {
            var other = coll.gameObject.GetComponent<Activatable>();
            if (other)
            {
                other.Activate();
            }
        }
    }
}
