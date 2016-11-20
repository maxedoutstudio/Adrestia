using UnityEngine;
using System.Collections;

public class menuCameraScript : MonoBehaviour 
{
	public float cameraRotateSpeed;

	void Start () 
	{
		cameraRotateSpeed = 5f;
	}

	void Update () 
	{
		transform.Rotate(new Vector3(0, cameraRotateSpeed * Time.deltaTime, 0));
	}
}
