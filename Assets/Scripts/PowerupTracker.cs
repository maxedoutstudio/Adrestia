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

	private bool canBackward;
	private bool canLeftRight;
	private bool canSprint;
	private bool canFire;
	private bool canLightning;
	private bool canWater;

	void Start()
	{
		canBackward = false;
		canLeftRight = false;
		canSprint = false;
		canFire = false;
		canLightning = false;
		canWater = false;
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

}
