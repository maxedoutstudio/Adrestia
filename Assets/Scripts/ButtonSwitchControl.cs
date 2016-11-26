using UnityEngine;
using System.Collections;

public class ButtonSwitchControl : MonoBehaviour {

	public bool pressed = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (pressed && transform.position.y > 9) {
			transform.position = new Vector3 (transform.position.x, transform.position.y - 0.02f, transform.position.z);
		}
	}
}
