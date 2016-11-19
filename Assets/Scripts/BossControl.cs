using UnityEngine;
using System.Collections;

public class BossControl : MonoBehaviour {

	public bool isHit = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Animator> ().SetBool ("isHit", isHit);
		if (isHit)
			isHit = false;
	}

	void OnCollisionEnter (Collision col) {
		print ("Collide");
		isHit = true;
	}
}
