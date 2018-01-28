using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Activatable))]
public class Infection : MonoBehaviour
{
    public Color infectedColor = new Color(.6f, .6f, .5f);
    public Color deadColor = new Color(1, 1, 1);
	public float lifetime;
	public float timeUntilDeath;
	private SpriteRenderer sr;

	// Use this for initialization
	void Start()
	{
		timeUntilDeath = lifetime;
		sr = gameObject.GetComponent<SpriteRenderer> ();
	}

	// Update is called once per frame
	void Update()
	{
		if (gameObject.GetComponent<Activatable> ().activated) {
			if (timeUntilDeath <= 0) {
				Die ();
			} else {
				timeUntilDeath -= Time.deltaTime;
				float fraction = timeUntilDeath / lifetime;
                sr.color = infectedColor * fraction + deadColor * (1 - fraction);
            }
        }
	}

	void Die(){
		print (gameObject.name + " died! rip");
		sr.color = new Color (1f,1f,1f);
		gameObject.GetComponent<Activatable> ().Deactivate ();

        Animator anim = gameObject.GetComponent<Animator>();
        if (anim) {
            anim.enabled = false;
        }

	}
	void OnCollisionEnter2D(Collision2D coll)
	{
		if (gameObject.GetComponent<Activatable> ().hasBeenActivated) {
			var other = coll.gameObject.GetComponent<Activatable> ();
			if (other && !other.hasBeenActivated) {
				other.Activate ();
				var otherinfection = coll.gameObject.GetComponent<Infection> ();
				if (otherinfection) {
					otherinfection.timeUntilDeath = otherinfection.lifetime;
                    otherinfection.gameObject.tag = "Infected";
				}
			}
		}
	}
    void OnTriggerEnter2D(Collider2D coll) {
        if (gameObject.GetComponent<Activatable>().hasBeenActivated) {
            var other = coll.gameObject.GetComponent<Activatable>();
            if (other && !other.hasBeenActivated) {
                other.Activate();
                var otherinfection = coll.gameObject.GetComponent<Infection>();
                if (otherinfection) {
                    otherinfection.timeUntilDeath = otherinfection.lifetime;
                    otherinfection.gameObject.tag = "Infected";
                }
            }
        }
    }
}
