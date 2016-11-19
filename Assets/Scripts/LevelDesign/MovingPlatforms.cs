using UnityEngine;
using System.Collections;

public class MovingPlatforms : MonoBehaviour {

	[SerializeField]
	Mesh m;

	[SerializeField]
	Transform platform;

	[SerializeField]
	Transform startTransform;

	[SerializeField]
	Transform endTransform;

	[SerializeField]
	float movementSpeed;

	private Rigidbody rbPlatform;
	private Vector3 direction;
	private Transform destination;

	void Start()
	{
		rbPlatform = platform.GetComponent<Rigidbody> ();
		setDestination (startTransform);
	}

	void FixedUpdate() 
	{
		rbPlatform.MovePosition (platform.position + direction * movementSpeed * Time.fixedDeltaTime);

		if (Vector3.Distance (platform.position, destination.position) < movementSpeed * Time.fixedDeltaTime) 
		{
			setDestination (destination == startTransform ? endTransform : startTransform);
		}
	}

	void OnDrawGizmos()
	{
		Gizmos.color = Color.green;
		Gizmos.DrawMesh(m, startTransform.position, platform.rotation, platform.localScale);

		Gizmos.color = Color.red;
		Gizmos.DrawMesh(m, endTransform.position, platform.rotation, platform.localScale);

	}

	void setDestination(Transform d)
	{
		destination = d;
		direction = (destination.position - platform.position).normalized;
	}
}
