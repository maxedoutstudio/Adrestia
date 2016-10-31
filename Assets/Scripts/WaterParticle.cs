using UnityEngine;
using System.Collections;

public class WaterParticle : MonoBehaviour
{
    void OnParticleCollision(GameObject obj)
    {
        if(obj.tag == "WeakToWater")
        {
            Destroy(obj);
        }

        if(obj.name != "Mage" && obj.name != "Planet")
        {
            gameObject.GetComponent<ParticleSystem>().Clear();
        }
    }
}
