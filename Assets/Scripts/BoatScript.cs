using UnityEngine;
using System.Collections;

public class BoatScript : MonoBehaviour 
{
    public GameObject otherBoat;

    bool moveBoats;
    bool stopBoats;

    Transform otherBoatTransform;

    void Start () 
    {
        otherBoatTransform = otherBoat.GetComponent<Transform>();
        moveBoats = false;
        stopBoats = false;
	}
	
	void Update () 
    {
        if(moveBoats == true)
        {
            transform.Translate(Vector3.forward * 0.1f);
            otherBoatTransform.Translate(Vector3.forward * 0.1f);

        }
	}

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.name == "Mage")
        {
            moveBoats = true;
        }

        if(col.gameObject.tag == "Wall")
        {
            moveBoats = false;
        }
    }
}
