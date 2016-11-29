using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BossBulletController : MonoBehaviour {

	public AudioClip firework;
	float loadTime = 0f;

	public AudioSource deathSound;
	AudioSource myDeathSound;
	// Use this for initialization
	void Start () {
		myDeathSound = deathSound.GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (loadTime > 0f) {
			loadTime -= Time.deltaTime;
		} else if (loadTime < 0f) {
			SceneManager.LoadScene ("BossWorld");
			loadTime = 0f;
		}
	}

	void OnParticleCollision (GameObject col){
		if (col.gameObject.tag.Contains ("Planet")) {
			AudioSource.PlayClipAtPoint (firework, GameObject.FindGameObjectWithTag("Player").transform.position);
			//print ("audio");
		}

		if (col.gameObject.tag == "Player") {
			col.gameObject.GetComponent<Animator> ().SetBool ("isDead", true);
			col.gameObject.GetComponent<FirstPersonController> ().playDeathSound ();
			loadTime = 3f;
			print ("hit player");
		}
	}
}
