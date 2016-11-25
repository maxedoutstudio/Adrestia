using UnityEngine;
using System.Collections;

public class SecondaryBoatScript : MonoBehaviour 
{
    public GameObject otherBoat;
    BoatScript otherBoatScript;

    void Start () 
    {
        otherBoatScript = otherBoat.GetComponent<BoatScript>();
	}

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Player")
        {
            col.transform.SetParent(transform);
            otherBoatScript.Move();
        }
    }

    void OnCollisionExit(Collision col)
    {
        if(col.gameObject.tag == "Player")
        {
            col.transform.SetParent(null);
        }
    }
}
