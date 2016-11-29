using UnityEngine;
using System.Collections;
using UnityEngine.UI;

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

    public GameObject forwardText;
    public GameObject backwardText;
    public GameObject strafeText;
    public GameObject jumpText;
    public GameObject levitateText;
    public GameObject sprintText;

    public float fadeTime;

    void Update()
    {
        if (forwardText != null && forwardText.activeSelf == true)
        {
            if ((Input.GetKey(KeyCode.W)))
            {
                StartCoroutine(FadeOutPowerUp(forwardText));
            }
        }
        if (backwardText != null && backwardText.activeSelf == true)
        {
            if ((Input.GetKey(KeyCode.S)))
            {
                StartCoroutine(FadeOutPowerUp(backwardText));
            }
        }
        if (strafeText != null && strafeText.activeSelf == true)
        {
            if (Input.GetKey(KeyCode.A) || (Input.GetKey(KeyCode.A)))
            {
                StartCoroutine(FadeOutPowerUp(strafeText));
            }
        }
        if (jumpText != null && jumpText.activeSelf == true)
        {
            if ((Input.GetKey(KeyCode.Space)))
            {
                StartCoroutine(FadeOutPowerUp(jumpText));
            }
        }
        if (levitateText != null && levitateText.activeSelf == true)
        {
            if ((Input.GetKey(KeyCode.Space)))
            {
                StartCoroutine(FadeOutPowerUp(levitateText));
            }
        }
        if (sprintText != null && sprintText.activeSelf == true)
        {
            if ((Input.GetKey(KeyCode.LeftShift)))
            {
                StartCoroutine(FadeOutPowerUp(sprintText));
            }
        }

    }

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
        if (backwardText != null)
        {
            StartCoroutine(FadeInPowerUp(backwardText));
        }
	}

	public void aquireLeftRight()
	{
		canLeftRight = true;
		Destroy (leftRightPowerUp);
        if (strafeText != null)
        {
            StartCoroutine(FadeInPowerUp(strafeText));
        }
	}

	public void aquireSprint()
	{
		canSprint = true;
		Destroy (sprintPowerUp);
        if (sprintText != null)
        {
            StartCoroutine(FadeInPowerUp(sprintText));
        }
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
        if (jumpText != null)
        {
            StartCoroutine(FadeInPowerUp(jumpText));
        }
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
        if (levitateText != null)
        {
            StartCoroutine(FadeInPowerUp(levitateText));
            
        }
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

    private IEnumerator FadeOutPowerUp(GameObject powerup)
    {
        foreach (Transform child in powerup.transform)
        {
            child.GetComponent<RawImage>().CrossFadeAlpha(0.0f, fadeTime / 2.0f , false);
        }

        float timer = 0.0f;
        while(timer < fadeTime + 1.0f)
        {
            timer += Time.deltaTime;
            yield return null;
        }
        powerup.SetActive(false);
    }

    private IEnumerator FadeInPowerUp(GameObject powerup)
    {
        foreach (Transform child in powerup.transform)
        {
            child.GetComponent<CanvasRenderer>().SetAlpha(0.0f);
        }
        powerup.SetActive(true);

        foreach (Transform child in powerup.transform)
        {
            child.GetComponent<RawImage>().CrossFadeAlpha(2.0f, fadeTime/2.0f, false);
        }
        yield return null;
    }
}