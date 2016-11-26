using UnityEngine;
using System.Collections;

public class PickupRotator : MonoBehaviour {

    // Script to rotate and move up down the pickups (purely visual effect)

    public float rotateSpeed;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(transform.InverseTransformDirection(transform.up), 100.0f * Time.deltaTime);
	}
}
