using UnityEngine;
using System.Collections;

public class BoatScript : MonoBehaviour 
{
    public GameObject otherBoat;

    bool startMovement;
    bool moveForward;
    bool moveBackward;

    Transform otherBoatTransform;

    void Start () 
    {
        otherBoatTransform = otherBoat.GetComponent<Transform>();
        startMovement = false;
        moveForward = true;
        moveBackward = false;
	}
	
	void Update () 
    {
        if(startMovement == true)
        {
            if(moveForward == true)
            {
                transform.Translate(Vector3.forward * 0.1f);
                otherBoatTransform.Translate(Vector3.forward * 0.1f);
            }
            if(moveBackward == true)
            {
                transform.Translate(Vector3.back * 0.1f);
                otherBoatTransform.Translate(Vector3.back * 0.1f);
            }
        }
	}

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Player")
        {
            col.transform.SetParent(transform);
            startMovement = true;
        }

        if(col.gameObject.tag == "Wall")
        {
            moveForward = false;
            moveBackward = true;
        }

        if(col.gameObject.tag == "Dock")
        {
            moveBackward = false;
            moveForward = true;
        }
    }

    void OnCollisionExit(Collision col)
    {
        if(col.gameObject.tag == "Player")
        {
            col.transform.SetParent(null);
        }
    }

    public void Move()
    {
        startMovement = true;
    }
}
