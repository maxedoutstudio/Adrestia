using UnityEngine;
using System.Collections;

public class FireParticle : MonoBehaviour
{
    public AudioSource destructionSound;
    AudioSource myDestructionSound;

    void Start()
    {
        myDestructionSound = destructionSound.GetComponent<AudioSource>();
    }

    void OnParticleCollision(GameObject obj)
    {
        if(obj.tag == "WeakToFire")
        {
            Instantiate(myDestructionSound);
            Destroy(obj);
        }

		if (obj.tag == "Boss") {
			obj.GetComponent<BossControl> ().isHit = true;
			print ("Hit boss");
		}
       
        if(obj.name != "Mage" && obj.tag != "Planet")
        {
            gameObject.GetComponent<ParticleSystem>().Clear();
        }

		if(obj.tag == "fire_interaction")
		{
			Instantiate(myDestructionSound);
			boiler_puzzle.boiler_fire_time = 45.00f;

		}
    }
}
