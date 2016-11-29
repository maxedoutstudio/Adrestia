using UnityEngine;
using System.Collections;

public class CratePuzzle : MonoBehaviour 
{
	public GameObject crate1;
	public GameObject crate2;
	public GameObject crate3;
	public GameObject crate4;
	public GameObject crate5;
	public GameObject crate6;






	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	

	}

	void OnCollision(Collider col)
	{
		if (col.tag == "Mage") {
			//transform.position (0, -1f, 0);
		}
	}
}
