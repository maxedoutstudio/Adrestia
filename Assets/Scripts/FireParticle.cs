﻿using UnityEngine;
using System.Collections;

public class FireParticle : MonoBehaviour
{
    void OnParticleCollision(GameObject obj)
    {
        if(obj.tag == "WeakToFire")
        {
            Destroy(obj);
        }
       
        if(obj.name != "Mage" && obj.name != "Planet")
        {
            gameObject.GetComponent<ParticleSystem>().Clear();
        }
    }
}
