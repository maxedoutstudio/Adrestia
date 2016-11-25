using UnityEngine;
using System.Collections;

public class LeftPuzzleScript : MonoBehaviour 
{
    public GameObject plate1;
    public GameObject plate2;
    public GameObject plate3;
    public GameObject plate4;
    public GameObject plate5;
    public GameObject plate6;
    public GameObject plate7;
    public GameObject plate8;
    public GameObject plate9;

    LeftPuzzlePlateScript plate1Script;
    LeftPuzzlePlateScript plate2Script;
    LeftPuzzlePlateScript plate3Script;
    LeftPuzzlePlateScript plate4Script;
    LeftPuzzlePlateScript plate5Script;
    LeftPuzzlePlateScript plate6Script;
    LeftPuzzlePlateScript plate7Script;
    LeftPuzzlePlateScript plate8Script;
    LeftPuzzlePlateScript plate9Script;

    public GameObject resetPlate;
    LeftResetScript resetScript;

    public GameObject puzzleController;
    PuzzleController myController;

    int achieved;
    bool complete;

    void Start () 
    {
        resetScript = resetPlate.GetComponent<LeftResetScript>();
        plate1Script = plate1.GetComponent<LeftPuzzlePlateScript>();
        plate2Script = plate2.GetComponent<LeftPuzzlePlateScript>();
        plate3Script = plate3.GetComponent<LeftPuzzlePlateScript>();
        plate4Script = plate4.GetComponent<LeftPuzzlePlateScript>();
        plate5Script = plate5.GetComponent<LeftPuzzlePlateScript>();
        plate6Script = plate6.GetComponent<LeftPuzzlePlateScript>();
        plate7Script = plate7.GetComponent<LeftPuzzlePlateScript>();
        plate8Script = plate8.GetComponent<LeftPuzzlePlateScript>();
        plate9Script = plate9.GetComponent<LeftPuzzlePlateScript>();

        myController = puzzleController.GetComponent<PuzzleController>();
        achieved = 0;
        complete = false;
	}

	void Update ()
    {
        if(achieved == 9 && complete == false)
        {
            myController.setPuzzleLeftComplete();
            resetScript.setComplete();
            complete = true;

        }
	}

    public void incrementAchieved()
    {
        if(achieved < 9)
        {
            achieved ++;
            resetScript.setCanBeReset();
        }
    }

    public void resetAchieved()
    {
        achieved = 0;
        plate1Script.reset();
        plate2Script.reset();
        plate3Script.reset();
        plate4Script.reset();
        plate5Script.reset();
        plate6Script.reset();
        plate7Script.reset();
        plate8Script.reset();
        plate9Script.reset();
    }

    public void turnAllRed()
    {
        plate1Script.turnRed();
        plate2Script.turnRed();
        plate3Script.turnRed();
        plate4Script.turnRed();
        plate5Script.turnRed();
        plate6Script.turnRed();
        plate7Script.turnRed();
        plate8Script.turnRed();
        plate9Script.turnRed();
    }

    public void turnAllGreen()
    {
        plate1Script.turnGreen();
        plate2Script.turnGreen();
        plate3Script.turnGreen();
        plate4Script.turnGreen();
        plate5Script.turnGreen();
        plate6Script.turnGreen();
        plate7Script.turnGreen();
        plate8Script.turnGreen();
        plate9Script.turnGreen();
    }

    public void turnResetGreen()
    {
        resetScript.setComplete();
    }

    public int getAchieved()
    {
        return achieved;
    }
}
