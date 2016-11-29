using UnityEngine;
using System.Collections;



public class boiler_puzzle : MonoBehaviour {


	public static float boiler_fire_time=0.00f;
	public static float boiler_water_time=0.00f;
	public bool destroymountain=false;


	public GameObject blocker_1;
	public GameObject blocker_2;
	public GameObject blocker_3;



	// Use this for initialization
	void Start () 
	{



	}

	// Update is called once per frame
	void Update () {



		if (boiler_fire_time > 0 && boiler_water_time > 0) 
		{
			Destroy(GameObject.Find("boiler_fire"));
			Destroy(GameObject.Find("boiler_water"));
			Destroy (GameObject.Find("blocker_1"));
			Destroy (GameObject.Find("blocker_2"));
			Destroy (GameObject.Find("blocker_3"));

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
