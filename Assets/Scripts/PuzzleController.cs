using UnityEngine;
using System.Collections;

public class PuzzleController : MonoBehaviour 
{
    public GameObject cliff1;
    public GameObject cliff2;
    public GameObject cliff3;

    public GameObject leftPuzzleController;

    LeftPuzzleScript leftScript;

    Transform cliff1Transform;
    Transform cliff2Transform;
    Transform cliff3Transform;
	
    bool puzzleLeftComplete;
    bool puzzleRightComplete;

    void Awake()
    {
        DontDestroyOnLoad(this);
    }

    void Start () 
    {
        leftScript = leftPuzzleController.GetComponent<LeftPuzzleScript>();
        puzzleLeftComplete = false;
        puzzleRightComplete = false;
        cliff1Transform = cliff1.GetComponent<Transform>();
        cliff2Transform = cliff2.GetComponent<Transform>();
        cliff3Transform = cliff3.GetComponent<Transform>();
	}

	void Update () 
    {
        if(puzzleLeftComplete == true && puzzleRightComplete == true)
        {
            Destroy(cliff1);
            Destroy(cliff2);
            Destroy(cliff3);
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
}
