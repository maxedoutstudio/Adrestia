using UnityEngine;
using System.Collections;

public class RightPuzzleScript : MonoBehaviour 
{
    public GameObject plateUp;
    public GameObject plateDown;
    public GameObject plateLeft;
    public GameObject plateRight;
    public GameObject puzzleController;
    public GameObject rightReset;

    RightPuzzlePlateScript plateUpScript;
    RightPuzzlePlateScript plateDownScript;
    RightPuzzlePlateScript plateLeftScript;
    RightPuzzlePlateScript plateRightScript;
    RightResetScript rightResetScript;

    PuzzleController myController;

    int achieved;
    int randomNumber;

	void Start () 
    {
        rightResetScript = rightReset.GetComponent<RightResetScript>();
        plateUpScript = plateUp.GetComponent<RightPuzzlePlateScript>();
        plateDownScript = plateDown.GetComponent<RightPuzzlePlateScript>();
        plateLeftScript = plateLeft.GetComponent<RightPuzzlePlateScript>();
        plateRightScript = plateRight.GetComponent<RightPuzzlePlateScript>();
        myController = puzzleController.GetComponent<PuzzleController>();
        achieved = 0;
        randomNumber = 0;
	}
	
	void Update () 
    {
        if(achieved == 5)
        {
            myController.setPuzzleRightComplete();
        }

        if(randomNumber == 1)
        {
            plateUpScript.turnBlue();
        }
        if(randomNumber == 2)
        {
            plateDownScript.turnBlue();
        }
        if(randomNumber == 3)
        {
            plateLeftScript.turnBlue();
        }
        if(randomNumber == 4)
        {
            plateRightScript.turnBlue();
        }
	}

    public void incrementAchieved()
    {
        if(achieved < 5)
        {
            achieved ++;
        }
    }

    public void resetAchieved()
    {
        achieved = 0;
    }

    public void newRandom()
    {

    }

    public void turnAllGreen()
    {
        plateUpScript.turnGreen();
        plateDownScript.turnGreen();
        plateLeftScript.turnGreen();
        plateRightScript.turnGreen();
        rightResetScript.turnGreen();
    }

    public void allFailed()
    {
        plateUpScript.turnRed();
        plateDownScript.turnRed();
        plateLeftScript.turnRed();
        plateRightScript.turnRed();
        rightResetScript.setCanBeReset();
    }

    public void allReset()
    {
        plateUpScript.turnWhite();
        plateDownScript.turnWhite();
        plateLeftScript.turnWhite();
        plateRightScript.turnWhite();
    }
}
