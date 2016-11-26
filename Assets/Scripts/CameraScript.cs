using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

	public float yDist = 10;
	public float zDist = -5;

	public float rotationSpeed = 2f;
	public Transform player;

	void LateUpdate () {
		transform.position = player.position;
		transform.Rotate (0f, Input.GetAxis ("Horizontal") * Time.deltaTime * rotationSpeed, 0f);
	}
	void OnGUI () {
		if (GUI.Button (new Rect(Screen.width - 200f, 20f, 180f, 40f), "Spaceship level")) {
			//Application.LoadLevel (1);
		}
	}
}
