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

    public GameObject menu;

    public GameObject UIWater;
    public GameObject UIFire;
    public GameObject UILightning;

    public AudioSource deathSound;
    AudioSource myDeathSound;

    // audio stuff
    public AudioSource pickupSound;
    AudioSource myPickupSound;
    public AudioSource levitateSound;
    AudioSource myLevitateSound;
    public AudioClip fireSound;
    public AudioClip waterSound;
    public AudioClip lightningSound;
	public AudioClip walkingSound;
    public AudioClip powerSwitchSound;

    public AudioSource openPause;
    AudioSource myOpenPause;
    public AudioSource closePause;
    AudioSource myClosePause;

    // Skills
    public ParticleSystem myParticlesFire;
    public ParticleSystem myParticlesWater;
    public ParticleSystem myParticlesLightning;

	public bool cast;

    // Animation toggle vars
    bool grounded;
    bool isWalking;
    bool isRunning;
    bool isAttacking;
	public bool isCasting;

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
        myOpenPause = openPause.GetComponent<AudioSource>();
        myClosePause = closePause.GetComponent<AudioSource>();
        myDeathSound = deathSound.GetComponent<AudioSource>();
        myLevitateSound = levitateSound.GetComponent<AudioSource>();
        myPickupSound = pickupSound.GetComponent<AudioSource>();
        jumpForce = 400;
        runSpeed = 10;
        walkSpeed = 6;
        mouseSensitivityY = 1f;
        mouseSensitivityX = 1f;
        levitateForce = 400f;
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
		if (((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)) && put_GO.getCanLeftRight())
			|| ((Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) && put_GO.getCanBackward()) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) 
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
		float inputY = (!put_GO.getCanBackward() && (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))) ? 0 : Input.GetAxisRaw("Vertical");

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
                rigidbody.AddForce (transform.up * Time.deltaTime * levitateForce);
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

			if (GetComponent<SpellController>() != null)
				isCasting = GetComponent<SpellController> ().checkInRange (powerUp);
			isAttacking = !isCasting;
			if (isCasting) {
				ParticleSystem[] ps = GetComponent<GravityBody> ().planet.GetComponentsInChildren<ParticleSystem> ();
				ps [0].Play ();
				Destroy (ps [1].gameObject);
			}

			currentTime = Time.time + 0.4f;
		}

        // Powerup selector checks
        if (Input.GetKeyDown("1") && put_GO.getCanWater())
        {
            if(powerUp != 1)
            {    
                Debug.Log("Water selected");
                UIFire.SetActive(false);
                UILightning.SetActive(false);
                UIWater.SetActive(true);
                AudioSource.PlayClipAtPoint(powerSwitchSound, transform.position);
                powerUp = 1;
            }
        }
        else if (Input.GetKeyDown("2") && put_GO.getCanFire())
        {
            if(powerUp != 2)
            {
                Debug.Log("Fire selected");
                UIWater.SetActive(false);
                UILightning.SetActive(false);
                UIFire.SetActive(true);
                AudioSource.PlayClipAtPoint(powerSwitchSound, transform.position);
                powerUp = 2;
            }
        }
        else if (Input.GetKeyDown("3") && put_GO.getCanLightning())
        {
            if(powerUp != 3)
            {
                Debug.Log("Lightning selected");
                UIWater.SetActive(false);
                UIFire.SetActive(false);
                UILightning.SetActive(true);
                AudioSource.PlayClipAtPoint(powerSwitchSound, transform.position);
                powerUp = 3;
            }
        }

        if (isAttacking && Time.time > currentTime)
        {
            switch (powerUp)
            {
                case 1: myParticlesWater.Play(); AudioSource.PlayClipAtPoint(waterSound, transform.position); break;
                case 2: myParticlesFire.Play(); AudioSource.PlayClipAtPoint(fireSound, transform.position); break;
                case 3: myParticlesLightning.Play(); AudioSource.PlayClipAtPoint(lightningSound, transform.position); break;
            }
            isAttacking = false;
            nextAttackDelay = Time.time + 0.5f;
            waiting = false;
        }

		if (isCasting && Time.time > currentTime)
		{
			isCasting = false;
			cast = false;
			nextAttackDelay = Time.time + 0.5f;
			waiting = false;
		}
            
		if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(menu.activeSelf == true)
            {
                menu.SetActive(false);
				Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                Instantiate(myClosePause);
            }
            else if(menu.activeSelf == false)
            {
                menu.SetActive(true);
				Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                Instantiate(myOpenPause);
            }
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

            case "FireSkill": put_GO.aquireFire(); GameObject.Find("warpGate").GetComponent<TeleportationPlateScript>().setShouldFlash(); break;
            case "WaterSkill": put_GO.aquireWater(); GameObject.Find("warpGate").GetComponent<TeleportationPlateScript>().setShouldFlash(); break;
            case "LightningSkill": put_GO.aquireLightning(); GameObject.Find("warpGate").GetComponent<TeleportationPlateScript>().setShouldFlash(); break;

            case "DoubleJumpSkill": put_GO.aquireDoubleJump(); break;
        }

		if (col.gameObject.tag == "DeathZone" || col.gameObject.tag == "SpearTrap" || col.gameObject.tag == "ShurikenTrap" || col.gameObject.tag == "BladeTrap" || col.gameObject.tag == "GreatAxeTrap") {
			Instantiate (myDeathSound);
			transform.position = new Vector3(1.898f, 109.97f, 2.12f);
			transform.rotation = new Quaternion(0f,0f,0f,0f);
			//SceneManager.LoadScene ("FirePlanet", LoadSceneMode.Single);
		}

        if (col.gameObject.name == "PlanetWater")
        {
           // SceneManager.LoadScene("Water");
            Instantiate(myDeathSound);
            transform.position = new Vector3(11.08f, 125.87f, -6.01f);
            transform.rotation = new Quaternion(0f,0f,0f,0f);

            GameObject.Find("boat1").GetComponent<BoatScript>().stopMove();
            GameObject.Find("boat1").transform.position = new Vector3(4.5f,62.9f,107f);
            GameObject.Find("boat1").transform.rotation = new Quaternion(0.5f, 0f, 0f, 0.9f);

            GameObject.Find("boat2").transform.position = new Vector3(-5.9f,62.8f,107f);
            GameObject.Find("boat2").transform.rotation = new Quaternion(0.5f, 0f, 0f, 0.9f);
        }


		if (col.gameObject.tag == "SpearTrapThunder" || col.gameObject.tag == "NeedleTrapThunder" || col.gameObject.tag == "SawBladeTrapThunder" || col.gameObject.tag == "GreatBladeTrapThunder" || col.gameObject.name == "ThunderPlanet"  ) {
			Instantiate (myDeathSound);
			transform.position = new Vector3(10f, 403f, -23f);
		}

		if (col.gameObject.tag == "orb" ) {

			Destroy(GameObject.FindGameObjectWithTag("orb2"));
			Destroy(GameObject.Find("orb"));
			Instantiate (lightningSound);
			Destroy(GameObject.Find("LightningWallExit"));
		}

		if (col.gameObject.tag == "orb2" ) {

			Destroy(GameObject.FindGameObjectWithTag("orb2"));
			Destroy(GameObject.Find("blocker_4"));
		}
	}

	public void playDeathSound() {
		Instantiate(myDeathSound);
	}
}
