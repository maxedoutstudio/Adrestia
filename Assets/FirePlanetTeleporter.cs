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

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.name == "Player" && myPowerUpTrackerScript.getCanFire()) {
			SceneManager.LoadScene ("Lightningworld");
		}
	}
}
