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

    public bool unlockAll;
    public bool tutorialDefault;
    public bool waterDefault;
    public bool fireDefault;
    public bool lightningDefault;
    public bool bossDefault;


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
		canBackward = unlockAll || waterDefault || fireDefault || lightningDefault || bossDefault;
        canLeftRight = unlockAll || waterDefault || fireDefault || lightningDefault || bossDefault;
        canSprint = unlockAll || waterDefault || fireDefault || lightningDefault || bossDefault;
        canJump = unlockAll || waterDefault || fireDefault || lightningDefault || bossDefault;
        canLevitate = unlockAll || waterDefault || fireDefault || lightningDefault || bossDefault;

        canDoubleJump = unlockAll || waterDefault || fireDefault || lightningDefault || bossDefault;

        canWater = unlockAll || fireDefault || lightningDefault || bossDefault;
        canFire = unlockAll || lightningDefault || bossDefault;
        canLightning = unlockAll || bossDefault;
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