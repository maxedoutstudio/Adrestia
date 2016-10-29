using UnityEngine;
using System.Collections;

[RequireComponent (typeof (GravityBody))]
public class FirstPersonController : MonoBehaviour {
	
	// public vars
	public float mouseSensitivityX = 1;
	public float mouseSensitivityY = 1;
	public float walkSpeed = 6;
    public float runSpeed = 10;
	public float jumpForce = 220;
	public LayerMask groundedMask;
	public PowerupTracker put_GO;
	
	// System vars
	bool grounded;
    bool isWalking;
    bool isRunning;

	Vector3 moveAmount;
	Vector3 smoothMoveVelocity;
	float verticalLookRotation;
	Transform cameraTransform;
	Rigidbody rigidbody;
    Animator animator;
	
    void Start() {
        
    }
	
	void Awake() {
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		cameraTransform = Camera.main.transform;
        rigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
	}
	
	void Update() {
		
		if (((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.A)) && put_GO.getCanLeftRight())
			|| (Input.GetKey(KeyCode.S) && put_GO.getCanBackward()) || Input.GetKey(KeyCode.W)) {
            isWalking = true;
        } else {
            isWalking = false;
        }

		isRunning = Input.GetKey(KeyCode.LeftShift) && put_GO.getCanSprint();

        animator.SetBool("isWalking", isWalking);
        animator.SetBool("isRunning", isRunning);

        // Look rotation:
		if (put_GO.getCanBackward()) transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * mouseSensitivityX);
		//verticalLookRotation += Input.GetAxis("Mouse Y") * mouseSensitivityY;
		//verticalLookRotation = Mathf.Clamp(verticalLookRotation,-30,30);
		//cameraTransform.localEulerAngles = Vector3.left * verticalLookRotation;

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
		
		if (Physics.Raycast(ray, out hit, 1 + .1f, groundedMask)) {
			grounded = true;
		} else {
			grounded = false;
		}

        animator.SetBool("isGrounded", grounded);
    }
	
	void FixedUpdate() {
		// Apply movement to rigidbody
		Vector3 localMove = transform.TransformDirection(moveAmount) * Time.fixedDeltaTime;
		rigidbody.MovePosition(rigidbody.position + localMove);
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
		}

		if (col.gameObject.tag == "LightningSkill")
		{
			put_GO.aquireLightning ();
		}

		if (col.gameObject.tag == "WaterSkill")
		{
			put_GO.aquireWater ();
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
