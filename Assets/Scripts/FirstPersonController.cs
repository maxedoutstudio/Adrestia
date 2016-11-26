using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

[RequireComponent (typeof (GravityBody))]
public class FirstPersonController : MonoBehaviour {
	
	// public vars
	public float mouseSensitivityX;
    public float mouseSensitivityY;
    public float walkSpeed;
    public float runSpeed;
    public float jumpForce;
	public float levitateForce;
	public LayerMask groundedMask;
	public PowerupTracker put_GO;

    public AudioSource deathSound;
    AudioSource myDeathSound;

	public ParticleSystem planet01;
	public ParticleSystem planet02;

    // audio stuff
    public AudioSource pickupSound;
    AudioSource myPickupSound;
    public AudioSource levitateSound;
    AudioSource myLevitateSound;
    public AudioClip fireSound;
    public AudioClip waterSound;
    public AudioClip lightningSound;
	public AudioClip walkingSound;

    // Skills
    public ParticleSystem myParticlesFire;
    public ParticleSystem myParticlesWater;
    public ParticleSystem myParticlesLightning;

    // Animation toggle vars
    bool grounded;
    bool isWalking;
    bool isRunning;
    bool isAttacking;
	bool isCasting;

    // Reference vars
    Transform cameraTransform;
    Rigidbody rigidbody;
    Animator animator;

    // Smoothing vars
    Vector3 moveAmount;
	Vector3 smoothMoveVelocity;
	
    // Powerup checks
    int powerUp;
    bool waiting;
    float currentTime;
    float nextAttackDelay;
	float verticalLookRotation;

    float nextJumpDelay;

	bool jumped;
    bool jumping;
    bool willLevitate;
    bool cancelLevitate;
    bool willLevitateAgain;
    float levitationTime;

    //Cam angle stuff
    float initCamAngle;
    bool mouseYEnabled;

    void Start()
    {
        myDeathSound = deathSound.GetComponent<AudioSource>();
        myLevitateSound = levitateSound.GetComponent<AudioSource>();
        myPickupSound = pickupSound.GetComponent<AudioSource>();
        jumpForce = 400;
        runSpeed = 10;
        walkSpeed = 6;
        mouseSensitivityY = 1f;
        mouseSensitivityX = 1f;
        levitateForce = 25f;
        levitationTime = 0f;
        jumped = false;
        jumping = false;
        willLevitate = false;
        cancelLevitate = false;
        willLevitateAgain = true;
        initCamAngle = -cameraTransform.localEulerAngles.x;
        mouseYEnabled = false;
    }
	
	void Awake() {
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		cameraTransform = Camera.main.transform;
        rigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        powerUp = 0;
	}
	
	void Update() {
		
        // Make sure movement mechanics are unlocked
		if (((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) && put_GO.getCanLeftRight())
			|| (Input.GetKey(KeyCode.S) && put_GO.getCanBackward()) || Input.GetKey(KeyCode.W)) 
        {
            isWalking = true;
        } 
        else 
        {
            isWalking = false;
        }

		isRunning = Input.GetKey(KeyCode.LeftShift) && put_GO.getCanSprint() && isWalking;

        // Look rotation; enable after left-right mechanic is unlocked
		if (put_GO.getCanLeftRight ()) {
            if (!mouseYEnabled)
            {
                verticalLookRotation = initCamAngle;
                mouseYEnabled = true;
            }
			transform.Rotate(Vector3.up * Input.GetAxis ("Mouse X") * mouseSensitivityX);
            verticalLookRotation += Input.GetAxis("Mouse Y") * mouseSensitivityY;
            verticalLookRotation = Mathf.Clamp(verticalLookRotation, -40, 5);
            cameraTransform.localEulerAngles = Vector3.left * verticalLookRotation;
		}

		// Calculate movement:
		float inputX = put_GO.getCanLeftRight() ? Input.GetAxisRaw("Horizontal") : 0;
		float inputY = (!put_GO.getCanBackward() && Input.GetKey(KeyCode.S)) ? 0 : Input.GetAxisRaw("Vertical");

        Vector3 moveDir = new Vector3(inputX, 0, inputY).normalized;
		Vector3 targetMoveAmount = moveDir * (isRunning ? runSpeed : walkSpeed);
        moveAmount = Vector3.SmoothDamp(moveAmount, targetMoveAmount, ref smoothMoveVelocity, .15f);

		// Jump
		if (Input.GetButtonDown("Jump") && grounded && put_GO.getCanJump()) 
        {
            grounded = false;
            cancelLevitate = false;
            nextJumpDelay = Time.time + 0.25f;
            willLevitate = false;
            willLevitateAgain = true;
            rigidbody.AddForce(transform.up * jumpForce);
        } 
        if (Input.GetButtonUp("Jump"))
        {
            willLevitate = true;
        }
        if (willLevitateAgain == true && willLevitate == true && Input.GetKey (KeyCode.Space) && !grounded && transform.InverseTransformDirection(rigidbody.velocity).y < 0 && put_GO.getCanLevitate()) 
        {
            if(cancelLevitate == false)
            {
                cancelLevitate = true;
                levitationTime = Time.time + 1f;
                Instantiate(myLevitateSound);
            }
            if(Time.time < levitationTime)
            {
                rigidbody.AddForce (transform.up * levitateForce);
            }
        }
        if(cancelLevitate == true && Input.GetButtonUp("Jump"))
        {
            Destroy(GameObject.Find("levitateSound(Clone)"));
            willLevitateAgain = false;
        }

		// Grounded check
		Ray ray = new Ray(transform.position, -transform.up);
		RaycastHit hit;

        if(Time.time > nextJumpDelay)
        {
    		if (Physics.Raycast(ray, out hit, 1 + .1f, groundedMask))
            {
                grounded = true;
                Destroy(GameObject.Find("levitateSound(Clone)"));
    		}
    		else
    		{
    			grounded = false;
    		}
        }

        // Mouse input
		if (Input.GetMouseButtonDown (0) && powerUp != 0 && Time.time > nextAttackDelay && waiting == false) {
			//isWalking = false;
			waiting = true;
			if ((transform.position.x > -1.8 && transform.position.x < 1.8) && (transform.position.z > -31 && transform.position.z < -28)) {
				isCasting = true;
				planet01.Play ();
			} else if ((transform.position.x > 24 && transform.position.x < 26) && (transform.position.z > -16 && transform.position.z < -14)) {
				isCasting = true;
				planet02.Play ();
			} else {
				isAttacking = true;
			}

			currentTime = Time.time + 0.4f;
		}

        // Powerup selector checks
        if (Input.GetKeyDown("1") && put_GO.getCanFire())
        {
            Debug.Log("Fire selected");
            powerUp = 1;
        }
        else if (Input.GetKeyDown("2") && put_GO.getCanWater())
        {
            Debug.Log("Water selected");
            powerUp = 2;
        }
        else if (Input.GetKeyDown("3") && put_GO.getCanLightning())
        {
            Debug.Log("Lightning selected");
            powerUp = 3;
        }

        if (isAttacking && Time.time > currentTime)
        {
            switch (powerUp)
            {
                case 1: myParticlesFire.Play(); AudioSource.PlayClipAtPoint(fireSound, transform.position); break;
                case 2: myParticlesWater.Play(); AudioSource.PlayClipAtPoint(waterSound, transform.position); break;
                case 3: myParticlesLightning.Play(); AudioSource.PlayClipAtPoint(lightningSound, transform.position); break;
            }
            isAttacking = false;
            nextAttackDelay = Time.time + 0.5f;
            waiting = false;
        }

		if (isCasting && Time.time > currentTime)
		{
			isCasting = false;
			nextAttackDelay = Time.time + 0.5f;
			waiting = false;
		}

        // Animation toggles
        animator.SetBool("isWalking", isWalking);
        animator.SetBool("isRunning", isRunning);
        animator.SetBool("isGrounded", grounded);
        animator.SetBool("isAttacking", isAttacking);
		animator.SetBool ("isCasting", isCasting);
    }
	
	void FixedUpdate() {
		// Apply movement to rigidbody
		Vector3 localMove = transform.TransformDirection(moveAmount) * Time.fixedDeltaTime;
		rigidbody.MovePosition(rigidbody.position + localMove);
	}

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag.Contains("Skill")) Instantiate(myPickupSound);

        switch (col.gameObject.tag)
        {
            case "BackwardSkill": put_GO.aquireBackward(); break;
            case "LeftRightSkill": put_GO.aquireLeftRight(); break;
            case "SprintSkill": put_GO.aquireSprint(); break;
            case "JumpSkill": put_GO.aquireJump(); break;
            case "LevitateSkill": put_GO.aquireLevitate(); break;

            case "FireSkill": put_GO.aquireFire(); powerUp = 1; break;
            case "WaterSkill": put_GO.aquireWater(); powerUp = 2; GameObject.Find("warpGate").GetComponent<TeleportationPlateScript>().setShouldFlash(); break;
            case "LightningSkill": put_GO.aquireLightning(); powerUp = 3; break;

            case "DoubleJumpSkill": put_GO.aquireDoubleJump(); break;
        }

		if (col.gameObject.tag == "DeathZone" || col.gameObject.tag == "SpearTrap" || col.gameObject.tag == "ShurikenTrap" || col.gameObject.tag == "BladeTrap" || col.gameObject.tag == "GreatAxeTrap")
			SceneManager.LoadScene("FirePlanet", LoadSceneMode.Single);

        if (col.gameObject.name == "PlanetWater")
        {
           // SceneManager.LoadScene("Water");
            Instantiate(myDeathSound);
            transform.position = new Vector3(11.08f, 125.87f, -6.01f);
            transform.rotation = new Quaternion(0f,0f,0f,0f);
        }

		if (col.gameObject.tag == "Switch")
			Destroy (col.gameObject);

		//if (col.gameObject.tag == "MovingPlatform")
    }

	/*void OnCollisionExit(Collision col)
	{
		if (col.gameObject.tag == "MovingPlatform")
	}*/
}
