using UnityEngine;
using System.Collections;

public class BossControl : MonoBehaviour {

	public bool isHit = false;
	public BlackHoleController blackHole01;
	public BlackHoleController blackHole02;
	public BlackHoleController blackHole03;
	public BlackHoleController blackHole04;

	public GravityBody Player;

	bool fireTop, waterTop, lightningTop;
	bool fireBot, waterBot, lightningBot;

	// Use this for initialization
	void Start () {
	
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
		}
	}

	public void Hit() {
		print (Player.planet.name);
		switch (Player.planet.name) {
			case "Fire01":
				fireBot = true;
				break;
			case "Fire02":
				fireTop = true;
				break;
			case "Water01":
				waterBot = true;
				break;
			case "Water02":
				waterTop = true;
				break;
			case "Lightning01":
				lightningTop = true;
				break;
			case "Lightning02":
				lightningBot = true;
				break;
		}

		print ("Collision");
		isHit = true;
	}
}
