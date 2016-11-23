using UnityEngine;
using System.Collections;

public class PuzzleController : MonoBehaviour 
{
    public GameObject cliff1;
    public GameObject cliff2;
    public GameObject cliff3;

    Transform cliff1Transform;
    Transform cliff2Transform;
    Transform cliff3Transform;
	
    bool puzzle1Complete;
    bool puzzle2Complete;

    void Start () 
    {
        puzzle1Complete = true;
        puzzle2Complete = true;
        cliff1Transform = cliff1.GetComponent<Transform>();
        cliff2Transform = cliff2.GetComponent<Transform>();
        cliff3Transform = cliff3.GetComponent<Transform>();
	}

	void Update () 
    {
        if(puzzle1Complete == true && puzzle2Complete == true)
        {
            Destroy(cliff1);
            Destroy(cliff2);
            Destroy(cliff3);
        }
	}

    public void setPuzzle1Complete()
    {
        puzzle1Complete = true;
    }

    public void setPuzzle2Complete()
    {
        puzzle2Complete = true;
    }
}
