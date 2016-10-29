using UnityEngine;
using System.Collections;

public class PowerupTracker : MonoBehaviour 
{
	public GameObject backwardPowerUp;
	public GameObject leftRightPowerUp;
	public GameObject sprintPowerUp;
	public GameObject firePowerUp;
	public GameObject lightningPowerUp;
	public GameObject waterPowerUp;
	public GameObject levitatePowerUp;
	public GameObject jumpPowerUp;
	public GameObject doubleJumpPowerUp;

	private bool canBackward;
	private bool canLeftRight;
	private bool canSprint;
	private bool canFire;
	private bool canLightning;
	private bool canWater;
	private bool canJump;
	private bool canDoubleJump;
	private bool canLevitate;

	void Start()
	{
		canBackward = false;
		canLeftRight = false;
		canSprint = false;
		canFire = false;
		canLightning = false;
		canWater = false;
		canJump = false;
		canDoubleJump = false;
		canLevitate = false;
	}

	public void aquireBackward()
	{
		canBackward = true;
		Destroy (backwardPowerUp);
	}

	public void aquireLeftRight()
	{
		canLeftRight = true;
		Destroy (leftRightPowerUp);
	}

	public void aquireSprint()
	{
		canSprint = true;
		Destroy (sprintPowerUp);
	}

	public void aquireFire()
	{
		canFire = true;
		Destroy (firePowerUp);
	}

	public void aquireLightning()
	{
		canLightning = true;
		Destroy (lightningPowerUp);
	}

	public void aquireWater()
	{
		canWater = true;
		Destroy (waterPowerUp);
	}

	public void aquireJump()
	{
		canJump = true;
		Destroy (jumpPowerUp);
	}

	public void aquireDoubleJump()
	{
		canDoubleJump = true;
		Destroy (doubleJumpPowerUp);
	}

	public void aquireLevitate()
	{
		canLevitate = true;
		Destroy(levitatePowerUp);
	}

	public bool getCanBackward()
	{
		return canBackward;
	}

	public bool getCanLeftRight()
	{
		return canLeftRight;
	}

	public bool getCanSprint()
	{
		return canSprint;
	}

	public bool getCanFire()
	{
		return canFire;
	}

	public bool getCanLightning()
	{
		return canLightning;
	}

	public bool getCanWater()
	{
		return canWater;
	}

	public bool getCanLevitate()
	{
		return canLevitate;
	}

	public bool getCanJump()
	{
		return canJump;
	}

	public bool getCanDoubleJump()
	{
		return canDoubleJump;
	}
}