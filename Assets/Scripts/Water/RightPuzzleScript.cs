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

    public AudioSource puzzleCompleteSound;
    AudioSource myPuzzleCompleteSound;

    public AudioSource spawnSound;
    AudioSource mySpawnSound;

    int achieved;
    int randomNumber;
    float randomGlowDelay;
    bool puzzleStart;
    bool complete;

    public AudioSource incorrectSound;
    AudioSource myIncorrectSound;

	void Start () 
    {
        mySpawnSound = spawnSound.GetComponent<AudioSource>();
        myIncorrectSound = incorrectSound.GetComponent<AudioSource>();
        myPuzzleCompleteSound = puzzleCompleteSound.GetComponent<AudioSource>();

        rightResetScript = rightReset.GetComponent<RightResetScript>();
        plateUpScript = plateUp.GetComponent<RightPuzzlePlateScript>();
        plateDownScript = plateDown.GetComponent<RightPuzzlePlateScript>();
        plateLeftScript = plateLeft.GetComponent<RightPuzzlePlateScript>();
        plateRightScript = plateRight.GetComponent<RightPuzzlePlateScript>();
        myController = puzzleController.GetComponent<PuzzleController>();
        achieved = 0;
        randomNumber = 0;
        randomGlowDelay = Time.time + 3.5f;
        puzzleStart = false;
        complete = false;
	}
	
	void Update () 
    {
        if(achieved == 5 && complete == false)
        {
            myController.setPuzzleRightComplete();
            turnAllGreen();
            complete = true;
            Instantiate(myPuzzleCompleteSound);
        }

        if(puzzleStart == true && complete == false)
        {
            if(Time.time > randomGlowDelay)
            {
                newRandom();
                if(randomNumber == 1)
                {
                    plateUpScript.turnBlue();
                    Instantiate(mySpawnSound);
                    randomGlowDelay = Time.time + 3.5f;
                }
                if(randomNumber == 2)
                {
                    plateDownScript.turnBlue();
                    Instantiate(mySpawnSound);
                    randomGlowDelay = Time.time + 3.5f;
                }
                if(randomNumber == 3)
                {
                    plateLeftScript.turnBlue();
                    Instantiate(mySpawnSound);
                    randomGlowDelay = Time.time + 3.5f;
                }
                if(randomNumber == 4)
                {
                    plateRightScript.turnBlue();
                    Instantiate(mySpawnSound);
                    randomGlowDelay = Time.time + 3.5f;
                }
            }
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
        randomNumber = Random.Range(1, 5);
        allReset();
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
        puzzleStart = false;
        Instantiate(myIncorrectSound);
    }

    public void allReset()
    {
        puzzleStart = true;
        plateUpScript.turnWhite();
        plateDownScript.turnWhite();
        plateLeftScript.turnWhite();
        plateRightScript.turnWhite();
    }

    public void setPuzzleStart()
    {
        puzzleStart = true;
    }

    public void setDoNotStart()
    {
        puzzleStart = false;
    }
}
