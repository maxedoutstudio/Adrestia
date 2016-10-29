using UnityEngine;
using System.Collections;

public class fireParticleScript : MonoBehaviour
{

	
	void Start () 
    {
	
	}
	
	
	void Update () 
    {
	
	}

    void OnParticleCollision(GameObject obj)
    {
        if(obj.tag == "BackwardSkill")
        {
            Destroy(obj);

        }


    }
}
