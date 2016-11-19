using UnityEngine;
using System.Collections;

public class GravityAttractor : MonoBehaviour {
	
	public float gravity = -9.8f;
	
	public void Attract(Rigidbody body) {

		Ray ray = new Ray(body.transform.position, -body.transform.up);
		RaycastHit hit;

		Physics.Raycast (ray, out hit);

		Vector3 gravityUp = hit.normal.normalized;
		Vector3 localUp = body.transform.up;

		// Apply downwards gravity to body
		body.AddForce(gravityUp * gravity);
        // Allign bodies up axis with the centre of planet
		body.GetComponent<GravityBody> ().up = body.rotation * body.GetComponent<GravityBody> ().up;
		body.GetComponent<GravityBody> ().forward = body.rotation * body.GetComponent<GravityBody> ().forward;

		body.rotation = Quaternion.RotateTowards(body.rotation, Quaternion.FromToRotation(localUp, gravityUp) * body.rotation, Time.fixedTime * 60);

		GameObject.FindGameObjectWithTag ("Boss").GetComponent<Transform> ().rotation = body.rotation * Quaternion.Euler(0, -180, 0);

	}  
}
