using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed = 12;
	private Vector3 moveDirection;
	
	void Update () {
		moveDirection = new Vector3 (Input.GetAxisRaw ("Horizontal"), 0, Input.GetAxisRaw ("Vertical")).normalized;


	}

	void FixedUpdate() {
		GetComponent<Rigidbody> ().MovePosition (GetComponent<Rigidbody>().position + transform.TransformDirection(moveDirection) * speed * Time.deltaTime);
	}


}
