using UnityEngine;
using System.Collections;

public class RightResetScript : MonoBehaviour 
{
    public GameObject puzzleController;
    RightPuzzleScript myController;

    public Material red;
    public Material white;
    public Material green;
    public Material blue;

    public GameObject plateUp;
    public GameObject plateDown;
    public GameObject plateLeft;
    public GameObject plateRight;

    RightPuzzlePlateScript plateUpScript;
    RightPuzzlePlateScript plateDownScript;
    RightPuzzlePlateScript plateLeftScript;
    RightPuzzlePlateScript plateRightScript;

    Renderer myRend;

    float flashDelay;
    bool flashWhite;
    bool shouldFlash;
    bool canBeReset;
    bool complete;

    public AudioSource puzzleStartSound;
    AudioSource myPuzzleStartSound;

	void Start () 
    {
        myPuzzleStartSound = puzzleStartSound.GetComponent<AudioSource>();

        plateUpScript = plateUp.GetComponent<RightPuzzlePlateScript>();
        plateDownScript = plateDown.GetComponent<RightPuzzlePlateScript>();
        plateLeftScript = plateLeft.GetComponent<RightPuzzlePlateScript>();
        plateRightScript = plateRight.GetComponent<RightPuzzlePlateScript>();
        myRend = GetComponent<Renderer>();
        myController = puzzleController.GetComponent<RightPuzzleScript>();
        flashDelay = Time.time + 0.5f;
        flashWhite = true;
        shouldFlash = true;
        canBeReset = true;
        complete = false;
	}
	
	void Update () 
    {
        if(Time.time > flashDelay && flashWhite == true && shouldFlash == true && canBeReset == true && complete == false)
        {
            turnWhite();
            flashWhite = false;
            flashDelay = Time.time + 0.5f;
        }
        if(Time.time > flashDelay && flashWhite == false && shouldFlash == true && canBeReset == true && complete == false)
        {
            turnBlue();
            flashWhite = true;
            flashDelay = Time.time + 0.5f;
        }
        if(canBeReset == false && complete == false)
        {
            turnWhite();
        }
	}

    public void turnGreen()
    {
        myRend.material = green;
        complete = true;
    }

    public void turnWhite()
    {
        myRend.material = white;
    }

    public void turnRed()
    {
        myRend.material = red;
    }

    public void turnBlue()
    {
        myRend.material = blue;
    }

    public void setCanBeReset()
    {
        canBeReset = true;
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Player" && canBeReset == true && complete == false)
        {
            Instantiate(myPuzzleStartSound);
            myController.allReset();
            canBeReset = false;
            myController.resetAchieved();
        }
    }

}
