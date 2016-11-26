using UnityEngine;
using System.Collections;

public class BridgeController : MonoBehaviour {

	bool grow = false;
	bool shrink = false;
	bool countdown = false;

	float time = 3f;

	void Update() {
		if (grow) {
			if (transform.localScale.x < 20 && transform.localScale.z < 20) {
				transform.localScale = new Vector3 (transform.localScale.x + 0.01f, transform.localScale.y, transform.localScale.z + 0.01f);
			} else {
				grow = false;
				countdown = true;
			}
		}

		if (countdown && time > 0f) {
			time -= Time.deltaTime;
		} else if (time < 0f) {
			countdown = false;
			shrink = true;
			time = 5f;
		}

		if (shrink) {
			if (transform.localScale.x > 2 && transform.localScale.z > 2) {
				transform.localScale = new Vector3 (transform.localScale.x - 0.01f, transform.localScale.y, transform.localScale.z - 0.01f);
			} else {
				shrink = false;
				grow = false;
				countdown = false;
				GetComponent<GravityAttractor> ().enabled = true;
			}
		}
	}

	void OnCollisionEnter (Collision col) {
		if (col.gameObject.tag == "Player" && !grow && !countdown && !shrink) {
			grow = true;
			GetComponent<GravityAttractor> ().enabled = false;
		}
	}
}
