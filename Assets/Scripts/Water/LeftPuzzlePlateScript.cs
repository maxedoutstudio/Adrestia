using UnityEngine;
using System.Collections;

public class LeftPuzzlePlateScript : MonoBehaviour 
{
    public GameObject puzzleController;
    LeftPuzzleScript myController;
    GravityBody myGravity;

    public GameObject resetPlate;
    LeftResetScript resetScript;

    public Material red;
    public Material white;
    public Material green;
    public Material blue;

    Renderer myRend;

    float movementTime;
    float delayTime;

    bool ascend;
    bool descend;
    bool puzzleStart;
    bool collided;
    bool failed;
    bool moving;
    bool complete;

    public AudioSource correctSound;
    AudioSource myCorrectSound;
	
    void Start () 
    {
        myCorrectSound = correctSound.GetComponent<AudioSource>();

        resetScript = resetPlate.GetComponent<LeftResetScript>();
        myRend = GetComponent<Renderer>();
        myGravity = GetComponent<GravityBody>();
        myController = puzzleController.GetComponent<LeftPuzzleScript>();
        movementTime = Time.time + 3f;
        delayTime = Time.time + 0.5f;
        ascend = false;
        descend = false;
        puzzleStart = false;
        collided = false;
        failed = false;
        moving = false;
        complete = false;
	}
	
	void Update () 
    {
        if(Time.time > delayTime)
        {
            if(descend == true)
            {
                transform.Translate(Vector3.left * 0.1f);
            }
            /*if(Time.time < movementTime + 0.5f && descend == true)
            {
                moving = true;
                transform.Translate(Vector3.left * 0.1f);
            }
            else if(descend == true)
            {
                moving = false;
            }*/
        }
            
        if(ascend == true)
        {
            transform.Translate(Vector3.right * 0.1f);
        }
        /*if(Time.time < movementTime && ascend == true)
        {
            moving = true;
            transform.Translate(Vector3.right * 0.1f);
        }
        else if(ascend == true)
        {
            moving = false;
        }*/
	}

    public void reset()
    {
        if(puzzleStart == false)
        {
            puzzleStart = true;
            descend = false;
            ascend = true;
            movementTime = Time.time + 3f;
            collided = false;
        }

        if(collided == true)
        {
            puzzleStart = true;
            descend = false;
            ascend = true;
            movementTime = Time.time + 3f;
            collided = false;
        }
        turnWhite();
        failed = false;
        complete = false;
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
        failed = true;
    }

    public void turnBlue()
    {
        myRend.material = blue;
    }

    public bool getMoving()
    {
        return moving;
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Sand")
        {
            descend = false;
        }

        if(col.gameObject.tag == "Wall")
        {
            ascend = false;
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Player" && puzzleStart == true && collided == false && failed == false && complete == false)
        {
            ascend = false;
            descend = true;
            movementTime = Time.time + 3f;
            delayTime = Time.time + 0.5f;
            turnGreen();
            myController.incrementAchieved();
            collided = true;

            Instantiate(myCorrectSound);
        }
    }
}
