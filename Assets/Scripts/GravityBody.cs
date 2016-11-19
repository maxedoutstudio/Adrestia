using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody))]
public class GravityBody : MonoBehaviour {
	
	GravityAttractor planet;
	Rigidbody rigidbody;
	public Vector3 up, forward;

	bool changeGravity = false;
	Vector3 from, to;

	float time = 1f;
	
	void Awake () {
		planet = GameObject.FindGameObjectWithTag("Planet").GetComponent<GravityAttractor>();
		rigidbody = GetComponent<Rigidbody> ();

		// Disable rigidbody gravity and rotation as this is simulated in GravityAttractor script
		rigidbody.useGravity = false;
		rigidbody.constraints = RigidbodyConstraints.FreezeRotation;

		up = transform.up;
		forward = transform.forward;
	}

	void Update() {
		if (changeGravity) {
			transform.rotation = Quaternion.RotateTowards (transform.rotation, Quaternion.FromToRotation(from, to), 150 * Time.deltaTime);
			time -= Time.deltaTime;
		}

		if (time < 0) {
			changeGravity = false;
			time = 1f;
		}
		float zAxis = Input.GetAxis ("Vertical");
		float xAxis = Input.GetAxis ("Horizontal");

		Vector3 diff = (Camera.main.transform.up * zAxis + Camera.main.transform.right * xAxis);
		diff.Normalize();
		diff = transform.InverseTransformDirection(diff);
		diff.y = 0;
		diff = transform.TransformDirection(diff);
		//transform.LookAt(transform.position + diff, transform.up);

		Debug.DrawRay (transform.position, transform.up * 5);
		Debug.DrawRay (transform.position, diff * 5);

		forward = diff;

	}
	
	void FixedUpdate () {
		// Allow this body to be influenced by planet's gravity
		if (!changeGravity) planet.Attract(rigidbody);
	}

	void OnCollisionEnter(Collision col) {
		if (col.gameObject.tag == "Connection" && planet.gameObject.tag != "Connection") {
			changeGravity = true;
			from = transform.up;
			to = forward;
			planet = col.gameObject.GetComponent<GravityAttractor> ();
		}

		if (col.gameObject.tag.Contains("Planet") && !planet.gameObject.tag.Contains("Planet")) {
			changeGravity = true;
			from = transform.up;
			to = forward;
			planet = col.gameObject.GetComponent<GravityAttractor> ();
		}
	}
}