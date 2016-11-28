using UnityEngine;
using System.Collections;

public class RingTrigger : MonoBehaviour {

	AudioSource ring;

	// Use this for initialization
	void Start () {
		ring = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider col) {
		if (col.gameObject.tag == "Player") {
			ring.volume = 0.3f;
			ring.PlayOneShot (ring.clip);
		}
	}

	void OnTriggerExit (Collider col) {
		if (col.gameObject.tag == "Player") {
			ring.Stop ();
		}
	}
}
