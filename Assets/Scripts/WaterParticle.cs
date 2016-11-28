using UnityEngine;
using System.Collections;

public class WaterParticle : MonoBehaviour
{
    public AudioSource destructionSound;
    AudioSource myDestructionSound;


    void Start()
    {
        myDestructionSound = destructionSound.GetComponent<AudioSource>();
    }

    void OnParticleCollision(GameObject obj)
    {
        if(obj.tag == "WeakToWater")
        {
            Instantiate(myDestructionSound);
            Destroy(obj);
        }

		if (obj.tag == "Boss") {
			obj.GetComponent<BossControl> ().Hit ();
			print ("Hit boss");
		}

		if (obj.tag == "GrowOnWater") {
			obj.GetComponent<BridgeController> ().Grow();
		}

        if(obj.name != "Mage" && obj.tag != "Planet")
        {
            gameObject.GetComponent<ParticleSystem>().Clear();
        }

		if(obj.tag == "WeakToWater")
		{
			Instantiate(myDestructionSound);
			Destroy(obj);
		}

		if(obj.tag == "water_interaction")
		{
			Instantiate(myDestructionSound);
			boiler_puzzle.boiler_water_time =45.00f;

		}

    }
}
