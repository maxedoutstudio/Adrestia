using UnityEngine;
using System.Collections;

public class BridgeController : MonoBehaviour {

	bool grow = false;
	bool shrink = false;
	bool countdown = false;

	float time = 5f;

	void Update() {
		if (grow) {
			if (transform.localScale.x < 20 && transform.localScale.z < 20) {
				transform.localScale = new Vector3 (transform.localScale.x + 0.1f, transform.localScale.y, transform.localScale.z + 0.1f);
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
				transform.localScale = new Vector3 (transform.localScale.x - 0.1f, transform.localScale.y, transform.localScale.z - 0.1f);
			} else {
				shrink = false;
				grow = false;
				countdown = false;
			}
		}
	}

	void OnCollisionEnter (Collision col) {
		if (col.gameObject.tag == "Player" && !grow && !countdown && !shrink) {
			grow = true;
		}
	}
}
