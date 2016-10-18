using UnityEngine;
using System.Collections;

public class PowerupTracker : MonoBehaviour 
{
	private bool canBackward;
	private bool canLeftRight;
	private bool canSprint;
	private bool canCrouch;
	private bool canFire;
	private bool canLightning;
	private bool canWater;

	public GameObject firePowerUp;

	void Start()
	{
		canBackward = false;
		canLeftRight = false;
		canSprint = false;
		canCrouch = false;
		canFire = false;
		canLightning = false;
		canWater = false;

		GameObject fire = (GameObject)Instantiate (firePowerUp);
	}

	public void aquireBackward()
	{
		canBackward = true;
	}

	public void aquireLeftRight()
	{
		canLeftRight = true;
	}

	public void aquireSprint()
	{
		canSprint = true;
	}

	public void aquireCrouch()
	{
		canCrouch = true;
	}

	public void aquireFire()
	{
		canFire = true;
	}

	public void aquireLightning()
	{
		canLightning = true;
	}

	public void aquireWater()
	{
		canWater = true;
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

	public bool getCanCrouch()
	{
		return canCrouch;
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
