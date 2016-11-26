using UnityEngine;
using System.Collections;

public class LeftPuzzleGround : MonoBehaviour {

    public GameObject myController;
    LeftPuzzleScript controllerScript;

    //bool alreadyRed;

    void Start () 
    {
        //alreadyRed = false;
        controllerScript = myController.GetComponent<LeftPuzzleScript>();
	}

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Player" && controllerScript.getAchieved() > 0 && controllerScript.getAchieved() < 9)// && alreadyRed == false)
        {
            //alreadyRed = true;
            controllerScript.turnAllRed();
        }
    }

    /*public void resetAlreadyRed()
    {
        alreadyRed = false;
    }*/
}
