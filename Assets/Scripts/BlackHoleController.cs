using UnityEngine;
using System.Collections;

public class BlackHoleController : MonoBehaviour {

	Vector3 point, axis;

	// Use this for initialization
	void Start () {
		point = transform.position.y > 0 ? point = new Vector3 (0, 30, 0) : point = new Vector3 (0, -30, 0);
		axis = transform.position.y > 0 ? axis = Vector3.up : axis = Vector3.down;
	}
	
	// Update is called once per frame
	void Update () {
		transform.RotateAround (point, axis, 50 * Time.deltaTime);
	}
}
