using UnityEngine;
using System.Collections;

public class LeftResetScript : MonoBehaviour {

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

    public GameObject puzzleController;
    LeftPuzzleScript myController;

    public Material red;
    public Material white;
    public Material green;
    public Material blue;

    Renderer myRend;

    float flashDelay;
    bool flashWhite;
    bool shouldFlash;
    bool complete;
    bool canBeReset;

    public AudioSource puzzleStartSound;
    AudioSource myPuzzleStartSound;

    void Start () 
    {
        myPuzzleStartSound = puzzleStartSound.GetComponent<AudioSource>();

        plate1Script = plate1.GetComponent<LeftPuzzlePlateScript>();
        plate2Script = plate2.GetComponent<LeftPuzzlePlateScript>();
        plate3Script = plate3.GetComponent<LeftPuzzlePlateScript>();
        plate4Script = plate4.GetComponent<LeftPuzzlePlateScript>();
        plate5Script = plate5.GetComponent<LeftPuzzlePlateScript>();
        plate6Script = plate6.GetComponent<LeftPuzzlePlateScript>();
        plate7Script = plate7.GetComponent<LeftPuzzlePlateScript>();
        plate8Script = plate8.GetComponent<LeftPuzzlePlateScript>();
        plate9Script = plate9.GetComponent<LeftPuzzlePlateScript>();

        myRend = GetComponent<Renderer>();
        myController = puzzleController.GetComponent<LeftPuzzleScript>();
        flashDelay = Time.time + 0.5f;
        flashWhite = true;
        shouldFlash = true;
        complete = false;
        canBeReset = true;
	}
	
	void Update () 
    {
        if(Time.time > flashDelay && flashWhite == true && shouldFlash == true && complete == false && canBeReset == true)
        {
            turnWhite();
            flashWhite = false;
            flashDelay = Time.time + 0.5f;
        }
        if(Time.time > flashDelay && flashWhite == false && shouldFlash == true && complete == false && canBeReset == true)
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

    public void setComplete()
    {
        complete = true;
        turnGreen();
    }

    public void setCanBeReset()
    {
        canBeReset = true;
    }

    public void setCannotBeReset()
    {
        canBeReset = false;
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Player" && complete == false && canBeReset == true)
        {
            Instantiate(myPuzzleStartSound);
            myController.resetAchieved();
            canBeReset = false;
        }
    }
}
