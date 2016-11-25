using UnityEngine;
using System.Collections;

public class BoatScript : MonoBehaviour 
{
    public GameObject otherBoat;

    bool startMovement;
    bool moveForward;
    bool moveBackward;

    Transform otherBoatTransform;

    public float boatSpeed;

    void Start () 
    {
        otherBoatTransform = otherBoat.GetComponent<Transform>();
        startMovement = false;
        moveForward = true;
        moveBackward = false;
        boatSpeed = 0.15f;
	}
	
	void Update () 
    {
        if(startMovement == true)
        {
            if(moveForward == true)
            {
                transform.Translate(Vector3.forward * boatSpeed);
                otherBoatTransform.Translate(Vector3.forward * boatSpeed);
            }
            if(moveBackward == true)
            {
                transform.Translate(Vector3.back * boatSpeed);
                otherBoatTransform.Translate(Vector3.back * boatSpeed);
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
