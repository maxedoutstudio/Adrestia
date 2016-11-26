using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class FirePlanetTeleporter : MonoBehaviour {


	public GameObject powerUpTracker;
	PowerupTracker myPowerUpTrackerScript;

	void Start()
	{
		myPowerUpTrackerScript = powerUpTracker.GetComponent<PowerupTracker>();
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == "Player" && myPowerUpTrackerScript.getCanFire()) {
			SceneManager.LoadScene ("Lightningworld");
		}
	}
}
