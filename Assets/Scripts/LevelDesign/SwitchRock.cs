using UnityEngine;
using System.Collections;

public class SwitchRock : MonoBehaviour {

	public GameObject rock;
	public AudioSource destructionSound;
	AudioSource myDestructionSound;

	void Start () {
	
		myDestructionSound = destructionSound.GetComponent<AudioSource>();
	}

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "Player") {
			Instantiate (myDestructionSound);
			Destroy (rock);
		}
	}
}
