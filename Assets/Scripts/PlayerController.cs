using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed = 12;
	public PowerupTracker put_GO;

	private Vector3 moveDirection;

    ParticleSystem myParticlesFire;
    ParticleSystem myParticlesWater;
    ParticleSystem myParticlesLightning;

    Animator mageAnimator;
    private int power = 0;
    bool imAttacking;
    bool imMoving;
    float currentTime;
    float nextAttackDelay;
    bool waiting;

    void Start()
    {
        waiting = false;
        nextAttackDelay =0;
        currentTime = 0;
        imAttacking = false;
        imMoving = false;
        mageAnimator = GetComponent<Animator>();
        myParticlesFire = GameObject.Find("MageWhite/Fire").GetComponent<ParticleSystem>();
        myParticlesWater = GameObject.Find("MageWhite/Water").GetComponent<ParticleSystem>();
        myParticlesLightning = GameObject.Find("MageWhite/Lightning").GetComponent<ParticleSystem>();
    }
	
	void Update () {

        mageAnimator.SetBool("isMoving", imMoving);
        mageAnimator.SetBool("isAttacking", imAttacking);

        if (Input.GetKey("w"))
        {
            moveDirection = new Vector3 (Input.GetAxisRaw ("Horizontal"), 0, Input.GetAxisRaw ("Vertical")).normalized;
            imMoving = true;
        }

		if (Input.GetKeyDown ("space") && put_GO.getCanJump())
        {
            Debug.Log ("Jump!");
        }

        if (Input.GetKey("s") && put_GO.getCanBackward())
        {
            moveDirection = new Vector3 (Input.GetAxisRaw ("Horizontal"), 0, Input.GetAxisRaw ("Vertical")).normalized;
            imMoving = true;
            Debug.Log("Backward!");
        }

        if(Input.GetKey("a") && put_GO.getCanLeftRight())
        {
            moveDirection = new Vector3 (Input.GetAxisRaw ("Horizontal"), 0, Input.GetAxisRaw ("Vertical")).normalized;
            imMoving = true;
            Debug.Log("Left!");
        }

        if(Input.GetKey("d") && put_GO.getCanLeftRight())
        {
            moveDirection = new Vector3 (Input.GetAxisRaw ("Horizontal"), 0, Input.GetAxisRaw ("Vertical")).normalized;
            imMoving = true;
            Debug.Log("Right!");
        }

        if(Input.GetKeyDown("left shift") && put_GO.getCanSprint())
        {
            Debug.Log("Sprint!");
        }

        if(Input.GetKey("space") && put_GO.getCanLevitate())
        {
            Debug.Log("Levitate!");
        }

        if(Input.GetKeyDown("1") && put_GO.getCanFire())
        {
            Debug.Log("Fire!");
            power = 1;
        }

        if(Input.GetKeyDown("2") && put_GO.getCanWater())
        {
            Debug.Log("Water!");
            power = 2;
        }

        if(Input.GetKeyDown("3") && put_GO.getCanLightning())
        {
            Debug.Log("Lightning!");
            power = 3;
        }

        if (Input.GetMouseButtonDown(0) && power != 0 && Time.time > nextAttackDelay && waiting == false)
        {
            waiting = true;
            imAttacking = true;
            imMoving = false;
            currentTime = Time.time + 0.4f;
        }

        if(imAttacking == true && Time.time > currentTime)
        {
            if(power == 1)
            {
                myParticlesFire.Play();
            }

            if(power == 2)
            {
                myParticlesWater.Play();
            }
            if(power == 3)
            {
                myParticlesLightning.Play();
            }
            imAttacking = false;
            nextAttackDelay = Time.time + 0.5f;
            waiting = false;
        }

        if(Input.GetKeyUp("w"))
        {
            imMoving = false;
            moveDirection = new Vector3 (Input.GetAxisRaw ("Horizontal"), 0, Input.GetAxisRaw ("Vertical")).normalized;
        }
        if(Input.GetKeyUp("a"))
        {
            imMoving = false;
            moveDirection = new Vector3 (Input.GetAxisRaw ("Horizontal"), 0, Input.GetAxisRaw ("Vertical")).normalized;
        }
        if(Input.GetKeyUp("s"))
        {
            imMoving = false;
            moveDirection = new Vector3 (Input.GetAxisRaw ("Horizontal"), 0, Input.GetAxisRaw ("Vertical")).normalized;
        }
        if(Input.GetKeyUp("d"))
        {
            imMoving = false;
            moveDirection = new Vector3 (Input.GetAxisRaw ("Horizontal"), 0, Input.GetAxisRaw ("Vertical")).normalized;
        }
	}

	void FixedUpdate() 
    {
		GetComponent<Rigidbody> ().MovePosition (GetComponent<Rigidbody>().position + transform.TransformDirection(moveDirection) * speed * Time.deltaTime);
	}

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "BackwardSkill")
        {
			put_GO.aquireBackward ();
        }

		if (col.gameObject.tag == "LeftRightSkill")
        {
			put_GO.aquireLeftRight ();
        }

		if (col.gameObject.tag == "SprintSkill")
        {
			put_GO.aquireSprint ();
        }

		if (col.gameObject.tag == "FireSkill")
        {
			put_GO.aquireFire ();
            power = 1;
        }

		if (col.gameObject.tag == "LightningSkill")
        {
			put_GO.aquireLightning ();
            power = 3;
        }
		
		if (col.gameObject.tag == "WaterSkill")
        {
			put_GO.aquireWater ();
            power = 2;
        }

        if(col.gameObject.tag == "JumpSkill")
        {
            put_GO.aquireJump();
        }

        if(col.gameObject.tag == "DoubleJumpSkill")
        {
            put_GO.aquireDoubleJump();
        }

        if(col.gameObject.tag == "LevitateSkill")
        {
            put_GO.aquireLevitate();
        }
	}
}
