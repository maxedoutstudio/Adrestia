using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class FirePlanetTeleporter : MonoBehaviour {


	public GameObject powerUpTracker;
	PowerupTracker myPowerUpTrackerScript;
	public GameObject loadingScreen;
	public AudioSource warpSound;
	AudioSource myWarpSound;

	void Start()
	{
		myPowerUpTrackerScript = powerUpTracker.GetComponent<PowerupTracker>();
		myWarpSound = warpSound.GetComponent<AudioSource>();
	}

	void Update ()
	{
		if (myPowerUpTrackerScript.getCanFire ()) {
			Instantiate(myWarpSound);
			gameObject.GetComponent<ParticleSystem>().Play();
		}
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == "Player" && myPowerUpTrackerScript.getCanFire()) {
			loadingScreen.SetActive(true);
			//SceneManager.LoadScene ("Lightningworld");
		}
	}
}
