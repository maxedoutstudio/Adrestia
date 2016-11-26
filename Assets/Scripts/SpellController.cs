using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpellController : MonoBehaviour {

	GravityBody body;

	List<string> visited;

	// Use this for initialization
	void Start () {
		body = GetComponent<GravityBody> ();
		visited = new List<string> ();
	}
	
	// Update is called once per frame
	void Update () {

	}

	public bool checkInRange(int powerUp) {
		if (visited.Contains (body.planet.name)) {
			return false;
		}
		if ((powerUp == 1 && body.planet.name.Contains ("Water"))
		    || (powerUp == 2 && body.planet.name.Contains ("Fire"))
		    || (powerUp == 3 && body.planet.name.Contains ("Lightning"))) {
			visited.Add (body.planet.name);
			print (transform.position);
			print (body.planet.transform.position);
			return (transform.position.x > body.planet.transform.position.x - 1
			&& transform.position.x < body.planet.transform.position.x + 1
			&& transform.position.z > body.planet.transform.position.z - 1
			&& transform.position.z < body.planet.transform.position.z + 1);
		} else {
			return false;
		}
	}
}
