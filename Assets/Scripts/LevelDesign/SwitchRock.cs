using UnityEngine;
using System.Collections;

public class SwitchRock : MonoBehaviour {

	public GameObject rock;
	public AudioSource destructionSound;
	AudioSource myDestructionSound;
	bool rockIsGone;

	void Start () {
	
		rockIsGone = false;
		myDestructionSound = destructionSound.GetComponent<AudioSource>();
	}

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "Player") {
			if (!rockIsGone) {
				Instantiate (myDestructionSound);
				Destroy (rock);
				rockIsGone = true;
			}
		}
	}
}
