using UnityEngine;
using System.Collections;

public class PuzzleController : MonoBehaviour 
{
    public GameObject cliff1;
    public GameObject cliff2;
    public GameObject cliff3;
    public AudioSource rumbleSound;
    AudioSource myRumbleSound;

    public GameObject leftPuzzleController;

    LeftPuzzleScript leftScript;

    Transform cliff1Transform;
    Transform cliff2Transform;
    Transform cliff3Transform;
	
    public bool puzzleLeftComplete;
    public bool puzzleRightComplete;
    bool passageOpen;
    bool destroyTheCliffs;

    void Start () 
    {
        destroyTheCliffs = false;
        myRumbleSound = rumbleSound.GetComponent<AudioSource>();
        leftScript = leftPuzzleController.GetComponent<LeftPuzzleScript>();
        puzzleLeftComplete = false;
        puzzleRightComplete = false;
        cliff1Transform = cliff1.GetComponent<Transform>();
        cliff2Transform = cliff2.GetComponent<Transform>();
        cliff3Transform = cliff3.GetComponent<Transform>();
        passageOpen = false;
	}

	void Update () 
    {
        if(puzzleLeftComplete == true && puzzleRightComplete == true && passageOpen == false)
        {
            Invoke("StopCliffs", 9f);
            Destroy(cliff1, 9f);
            Destroy(cliff2, 9f);
            Destroy(cliff3, 9f);

            destroyTheCliffs = true;
            passageOpen = true;
            Instantiate(myRumbleSound);
        }

        if(destroyTheCliffs == true)
        {
            cliff1Transform.Translate(Vector3.down * Time.deltaTime * 4f);
            cliff2Transform.Translate(Vector3.down * Time.deltaTime * 4f);
            cliff3Transform.Translate(Vector3.down * Time.deltaTime * 4f);
        }
	}

    public void setPuzzleLeftComplete()
    {
        puzzleLeftComplete = true;
    }

    public void setPuzzleRightComplete()
    {
        puzzleRightComplete = true;
    }

    public void StopCliffs()
    {
        destroyTheCliffs = false;
    }
}
