using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed = 12;
	public PowerupTracker put_GO;

	private Vector3 moveDirection;
	
	void Update () {
		moveDirection = new Vector3 (Input.GetAxisRaw ("Horizontal"), 0, Input.GetAxisRaw ("Vertical")).normalized;

		if (Input.GetKeyDown ("space") && put_GO.getCanFire())
			Debug.Log ("Shoot Fire");

	}

	void FixedUpdate() {
		GetComponent<Rigidbody> ().MovePosition (GetComponent<Rigidbody>().position + transform.TransformDirection(moveDirection) * speed * Time.deltaTime);
	}

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "BackwardSkill")
			put_GO.aquireBackward ();

		if (col.gameObject.tag == "LeftRightSkill")
			put_GO.aquireLeftRight ();

		if (col.gameObject.tag == "SprintSkill")
			put_GO.aquireSprint ();

		if (col.gameObject.tag == "FireSkill")
			put_GO.aquireFire ();

		if (col.gameObject.tag == "LightningSkill")
			put_GO.aquireLightning ();
		
		if (col.gameObject.tag == "WaterSkill")
			put_GO.aquireWater ();
	}
}
