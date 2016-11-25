using UnityEngine;
using System.Collections;

public class LeftPuzzleGround : MonoBehaviour {

    public GameObject myController;
    LeftPuzzleScript controllerScript;

    void Start () 
    {
        controllerScript = myController.GetComponent<LeftPuzzleScript>();
	}

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Player" && controllerScript.getAchieved() > 0 && controllerScript.getAchieved() < 9)
        {
            controllerScript.turnAllRed();
        }
    }
}
