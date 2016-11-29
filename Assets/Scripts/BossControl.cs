using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BossControl : MonoBehaviour {

	public bool isHit = false;
	public bool isDead = false;
	public BlackHoleController blackHole01;
	public BlackHoleController blackHole02;
	public BlackHoleController blackHole03;
	public BlackHoleController blackHole04;

	public GravityBody Player;
	public ParticleSystem[] fShield;
	public ParticleSystem[] wShield;
	public ParticleSystem[] lShield;

	public AudioClip hit;
	public GameObject loadingScreen;

	bool fireTop, waterTop, lightningTop;
	bool fireBot, waterBot, lightningBot;

	int health;
	bool attack;

	float time = 2f;
	float returnToMenuTime = 1f;
	float attackDelay = 1f;
	Vector3 direction, target;

	// Use this for initialization
	void Start () {
		health = 6;
	}

	// Update is called once per frame
	void Update () {
		GetComponent<Animator> ().SetBool ("isHit", isHit);

		if (isHit) {
			isHit = false;
			blackHole01.Emit (fireTop, waterTop, lightningTop);
			blackHole02.Emit (fireTop, waterTop, lightningTop);
			blackHole03.Emit (fireBot, waterBot, lightningBot);
			blackHole04.Emit (fireBot, waterBot, lightningBot);
		} else if (isDead && health == 0) {
			GetComponent<Animator>().SetBool ("isDead", isDead);
			direction = (Player.gameObject.transform.position - transform.position).normalized;
			Vector3 adjust = Player.gameObject.transform.position.y > 0 ? new Vector3 (0, 10, 0) : new Vector3 (0, -10, 0);
			target = (transform.position + 20 * direction) - adjust;
			health--;
			blackHole01.StopEmit ();
			blackHole02.StopEmit ();
			blackHole03.StopEmit ();
			blackHole04.StopEmit ();
		}

		if (isDead && time > 0f) {
			transform.position = Vector3.MoveTowards (transform.position, target, 30 * Time.deltaTime);
			time -= Time.deltaTime;
		}

		if (time <= 0f && returnToMenuTime > 0f) {
			returnToMenuTime -= Time.deltaTime;
			if (returnToMenuTime <= 0f) {
				Time.timeScale = 1f;
				loadingScreen.SetActive (true);
			}
		}

		GetComponent<Animator> ().SetBool ("attack", attack);
		if (attack && attackDelay < 0f) {
			attack = false;
			attackDelay = 2f;
			Camera.main.GetComponent<CameraShake> ().shakeDuration = 2f;
		} else if (attack) {
			attackDelay -= Time.deltaTime;
		}
	}

	public void Hit() {
		print (Player.planet.name);
		AudioSource.PlayClipAtPoint (hit, Player.gameObject.transform.position);
		ParticleSystem.MinMaxCurve rate;
		switch (Player.planet.name) {
		case "Fire01":
			fireBot = true;
			Destroy (fShield [0].gameObject);
			fShield [0] = fShield [1];
				break;
			case "Fire02":
				fireTop = true;
			Destroy (fShield [0].gameObject);
			fShield [0] = fShield [1];
				break;
			case "Water01":
				waterBot = true;
			Destroy (wShield [0].gameObject);
			wShield [0] = wShield [1];
				break;
			case "Water02":
				waterTop = true;
			Destroy (wShield [0].gameObject);
			wShield [0] = wShield [1];
				break;
			case "Lightning01":
				lightningTop = true;
			Destroy (lShield [0].gameObject);
			lShield [0] = lShield [1];
				break;
			case "Lightning02":
				lightningBot = true;
				Destroy (lShield [0].gameObject);
				lShield [0] = lShield [1];
				break;
		}

		print ("Collision");
		health--;
		print (health);
		attack = health < 4 && health > 0;
		isHit = health > 0;
		isDead = health <= 0;
		if (isDead)
			Time.timeScale = 0.2f;
	}
}
