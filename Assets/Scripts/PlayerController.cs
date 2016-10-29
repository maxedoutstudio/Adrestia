using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed = 12;
	public PowerupTracker put_GO;

	private Vector3 moveDirection;

    ParticleSystem myParticlesFire;
    ParticleSystem myParticlesWater;
    ParticleSystem myParticlesLightning;

    private int power = 0;

    void Start()
    {
        myParticlesFire = GameObject.Find("MageWhite/Fire").GetComponent<ParticleSystem>();
        myParticlesWater = GameObject.Find("MageWhite/Water").GetComponent<ParticleSystem>();
        myParticlesLightning = GameObject.Find("MageWhite/Lightning").GetComponent<ParticleSystem>();
    }
	
	void Update () {
		moveDirection = new Vector3 (Input.GetAxisRaw ("Horizontal"), 0, Input.GetAxisRaw ("Vertical")).normalized;

		if (Input.GetKeyDown ("space") && put_GO.getCanJump())
        {
            Debug.Log ("Jump!");
        }

        if (Input.GetKeyDown("down") && put_GO.getCanBackward())
        {
            Debug.Log("Backward!");
        }

        if(Input.GetKeyDown("left") && put_GO.getCanLeftRight())
        {
            Debug.Log("Left!");
        }

        if(Input.GetKeyDown("right") && put_GO.getCanLeftRight())
        {
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

        if (Input.GetMouseButtonDown(0) && power != 0)
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
