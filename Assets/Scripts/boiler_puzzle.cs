using UnityEngine;
using System.Collections;



public class boiler_puzzle : MonoBehaviour {


	public static float boiler_fire_time=0.00f;
	public static float boiler_water_time=0.00f;
	public bool destroymountain=false;


	public GameObject blocker_1;
	public GameObject blocker_2;
	public GameObject blocker_3;

	Transform b1;
	Transform b2;
	Transform b3;

	// Use this for initialization
	void Start () 
	{

		b1 = blocker_1.GetComponent<Transform>();
		b2 = blocker_2.GetComponent<Transform>();
		b3 = blocker_3.GetComponent<Transform>();

	}

	// Update is called once per frame
	void Update () {

		if (destroymountain) 
		{
			Destroy (GameObject.Find("blocker_1"));
			Destroy (GameObject.Find("blocker_2"));
			Destroy (GameObject.Find("blocker_3"));
			//b1.Translate (Vector3.down * Time.deltaTime * 4f);
			//b2.Translate (Vector3.down * Time.deltaTime * 4f);
			//b3.Translate (Vector3.down * Time.deltaTime * 4f);

			//if (blocker_1.transform.position.y > -81.0f) {

			//}
		}

		if (boiler_fire_time > 0 && boiler_water_time > 0) 
		{

			Destroy(GameObject.Find("boiler_fire"));
			Destroy(GameObject.Find("boiler_water"));
			destroymountain = true;

		}

		if (boiler_fire_time > 0) 
		{
			print (boiler_fire_time);
			boiler_fire_time -= Time.deltaTime;
			print ("decrease time fire boiler" + boiler_fire_time);

		}

		if (boiler_water_time > 0) {

			boiler_water_time -= Time.deltaTime;
			print ("decrease time water boiler " + boiler_water_time);

		}
	}
}
