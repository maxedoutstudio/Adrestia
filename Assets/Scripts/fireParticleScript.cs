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
       
        if(obj.name != "MageWhite" && obj.name != "Planet")
        {
            gameObject.GetComponent<ParticleSystem>().Clear();
        }

    }
}
