using UnityEngine;
using System.Collections;

public class MovingShuriken : MonoBehaviour {

	[SerializeField]
	Mesh m;

	[SerializeField]
	Transform shuriken;

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
		rbPlatform = shuriken.GetComponent<Rigidbody> ();
		setDestination (startTransform);
	}

	void FixedUpdate() 
	{
		rbPlatform.MovePosition (shuriken.position + direction * movementSpeed * Time.fixedDeltaTime);

		if (Vector3.Distance (shuriken.position, destination.position) < movementSpeed * Time.fixedDeltaTime) 
		{
			setDestination (destination == startTransform ? endTransform : startTransform);
		}
	}

	void OnDrawGizmos()
	{
		Gizmos.color = Color.green;
		Gizmos.DrawMesh(m, startTransform.position, shuriken.rotation, shuriken.localScale);

		Gizmos.color = Color.red;
		Gizmos.DrawMesh(m, endTransform.position, shuriken.rotation, shuriken.localScale);

	}

	void setDestination(Transform d)
	{
		destination = d;
		direction = (destination.position - shuriken.position).normalized;
	}
}
