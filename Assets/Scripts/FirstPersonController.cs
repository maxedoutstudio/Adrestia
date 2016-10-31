using UnityEngine;
using System.Collections;

[RequireComponent (typeof (GravityBody))]
public class FirstPersonController : MonoBehaviour {
	
	// public vars
	public float mouseSensitivityX = 1;
	public float mouseSensitivityY = 1;
	public float walkSpeed = 6;
    public float runSpeed = 10;
	public float jumpForce = 500;
	public LayerMask groundedMask;
	public PowerupTracker put_GO;

    // Skills
    public ParticleSystem myParticlesFire;
    public ParticleSystem myParticlesWater;
    public ParticleSystem myParticlesLightning;

    // Animation toggle vars
    bool grounded;
    bool isWalking;
    bool isRunning;
    bool isAttacking;

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

    void Start()
    {
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
			|| (Input.GetKey(KeyCode.S) && put_GO.getCanBackward()) || Input.GetKey(KeyCode.W)) {
            isWalking = true;
        } else {
            isWalking = false;
        }

		isRunning = Input.GetKey(KeyCode.LeftShift) && put_GO.getCanSprint();

        // Look rotation; enable after backward mechanic is unlocked
		if (put_GO.getCanBackward()) transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * mouseSensitivityX);

		// Calculate movement:
		float inputX = put_GO.getCanLeftRight() ? Input.GetAxisRaw("Horizontal") : 0;
		float inputY = (!put_GO.getCanBackward() && Input.GetKey(KeyCode.S)) ? 0 : Input.GetAxisRaw("Vertical");

        Vector3 moveDir = new Vector3(inputX, 0, inputY).normalized;
		Vector3 targetMoveAmount = moveDir * (isRunning ? runSpeed : walkSpeed);
        moveAmount = Vector3.SmoothDamp(moveAmount, targetMoveAmount, ref smoothMoveVelocity, .15f);
		
		// Jump
		if (Input.GetButtonDown("Jump") && grounded && put_GO.getCanJump()) {
            rigidbody.AddForce(transform.up * jumpForce);
        }
		if (Input.GetKey (KeyCode.Space) && !grounded && rigidbody.velocity.y < 0 && put_GO.getCanLevitate()) {
			rigidbody.AddForce (transform.up * 16);
		}

        // Grounded check
        Ray ray = new Ray(transform.position, -transform.up);
		RaycastHit hit;
		
		if (Physics.Raycast(ray, out hit, 1 + .1f, groundedMask))
        {
            grounded = true;
		}
        else
        {
			grounded = false;
		}

        // Mouse input
        if (Input.GetMouseButtonDown(0) && powerUp != 0 && Time.time > nextAttackDelay && waiting == false)
        {
            waiting = true;
            isAttacking = true;
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
                case 1: myParticlesFire.Play(); break;
                case 2: myParticlesWater.Play(); break;
                case 3: myParticlesLightning.Play(); break;
            }
            isAttacking = false;
            nextAttackDelay = Time.time + 0.5f;
            waiting = false;
        }

        // Animation toggles
        animator.SetBool("isWalking", isWalking);
        animator.SetBool("isRunning", isRunning);
        animator.SetBool("isGrounded", grounded);
        animator.SetBool("isAttacking", isAttacking);
    }
	
	void FixedUpdate() {
		// Apply movement to rigidbody
		Vector3 localMove = transform.TransformDirection(moveAmount) * Time.fixedDeltaTime;
		rigidbody.MovePosition(rigidbody.position + localMove);
	}

    void OnCollisionEnter(Collision col)
    {
        switch (col.gameObject.tag)
        {
            case "BackwardSkill": put_GO.aquireBackward(); break;
            case "LeftRightSkill": put_GO.aquireLeftRight(); break;
            case "SprintSkill": put_GO.aquireSprint(); break;
            case "JumpSkill": put_GO.aquireJump(); break;
            case "LevitateSkill": put_GO.aquireLevitate(); break;

            case "FireSkill": put_GO.aquireFire(); powerUp = 1; break;
            case "WaterSkill": put_GO.aquireWater(); powerUp = 2; break;
            case "LightningSkill": put_GO.aquireLightning(); powerUp = 3; break;

            case "DoubleJumpSkill": put_GO.aquireDoubleJump(); break;
        }
    }
}
