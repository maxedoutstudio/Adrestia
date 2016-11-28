using UnityEngine;
using System.Collections;

public class BossBulletController : MonoBehaviour {

	public AudioClip firework;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnParticleCollision (GameObject col){
		if (col.gameObject.tag.Contains ("Planet")) {
			AudioSource.PlayClipAtPoint (firework, GameObject.FindGameObjectWithTag("Player").transform.position);
			//print ("audio");
		}

		if (col.gameObject.tag == "Player") {
			print ("hit player");
		}
	}
}
