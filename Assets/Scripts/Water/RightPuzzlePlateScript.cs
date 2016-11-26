using UnityEngine;
using System.Collections;

public class RightPuzzlePlateScript : MonoBehaviour {

    public GameObject puzzleController;
    RightPuzzleScript myController;

    public Material red;
    public Material white;
    public Material green;
    public Material blue;

    Renderer myRend;
    bool glowing;
    bool complete;
    float countDownTimer;
    bool failed;

    public AudioSource correctSound;
    AudioSource myCorrectSound;

    void Start () 
    {
        myCorrectSound = correctSound.GetComponent<AudioSource>();

        myRend = GetComponent<Renderer>();
        myController = puzzleController.GetComponent<RightPuzzleScript>();
        glowing = false;
        complete = false;
        countDownTimer = 0f;
        failed = false;
	}
	
	void Update () 
    {
        if(glowing == true && Time.time > countDownTimer && complete == false)
        {
            myController.allFailed();
            failed = true;
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
        glowing = false;
        failed = false;
    }

    public void turnRed()
    {
        myRend.material = red;
        glowing = false;
    }

    public void turnBlue()
    {
        myRend.material = blue;
        glowing = true;
        countDownTimer = Time.time + 3f;
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Player" && glowing == true && complete == false && failed == false)
        {
            turnWhite();
            myController.incrementAchieved();
            Instantiate(myCorrectSound);
        }
    }
}
