using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody))]
public class GravityBody : MonoBehaviour {
	
	GravityAttractor planet;
	Rigidbody rigidbody;
	
	void Awake () {
		planet = GameObject.FindGameObjectWithTag("Planet").GetComponent<GravityAttractor>();
		rigidbody = GetComponent<Rigidbody> ();

		// Disable rigidbody gravity and rotation as this is simulated in GravityAttractor script
		rigidbody.useGravity = false;
		rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
	}

	void Update() {
		// Debug rays
		float zAxis = Input.GetAxis ("Vertical");
		float xAxis = Input.GetAxis ("Horizontal");

		Vector3 diff = (Camera.main.transform.up * zAxis + Camera.main.transform.right * xAxis);
		diff.Normalize();
		diff = transform.InverseTransformDirection(diff);
		diff.y = 0;
		diff = transform.TransformDirection(diff);

		Debug.DrawRay (transform.position, transform.up * 5);
		Debug.DrawRay (transform.position, diff * 5);
	}
	
	void FixedUpdate () {
		// Allow this body to be influenced by planet's gravity
		planet.Attract(rigidbody);
	}

	void OnCollisionEnter(Collision col) {
		if (col.gameObject.tag == "Connection" && planet.gameObject.tag != "Connection") {
			planet = col.gameObject.GetComponent<GravityAttractor> ();
		}

		if (col.gameObject.tag.Contains("Planet") && !planet.gameObject.tag.Contains("Planet")) {
			planet = col.gameObject.GetComponent<GravityAttractor> ();
		}
	}
}