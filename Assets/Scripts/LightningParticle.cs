using UnityEngine;
using System.Collections;

public class LightningParticle : MonoBehaviour
{
    void OnParticleCollision(GameObject obj)
    {
        if(obj.tag == "WeakToLightning")
        {
            Destroy(obj);
        }

        if(obj.name != "Mage" && obj.name != "Planet")
        {
            gameObject.GetComponent<ParticleSystem>().Clear();
        }
    }
}
