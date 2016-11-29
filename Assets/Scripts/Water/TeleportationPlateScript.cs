using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TeleportationPlateScript : MonoBehaviour 
{
    public Material red;
    public Material white;
    public Material green;
    public Material blue;

    public GameObject loadingScreen;

    Renderer myRend;

    float flashDelay;
    bool flashWhite;
    bool shouldFlash;

    public AudioSource warpSound;
    AudioSource myWarpSound;

    public GameObject powerUpTracker;
    PowerupTracker myPowerUpTrackerScript;

    public GameObject sceneStory;

    void Start()
    {
        myPowerUpTrackerScript = powerUpTracker.GetComponent<PowerupTracker>();
        myWarpSound = warpSound.GetComponent<AudioSource>();

        myRend = GetComponent<Renderer>();
        flashDelay = Time.time + 0.5f;
        flashWhite = true;
        shouldFlash = false;
    }

    void Update()
    {
        //if(myPowerUpTrackerScript.getCanWater() == true)
        //{
        //    setShouldFlash();
        //}

        /*if(Time.time > flashDelay && flashWhite == true && shouldFlash == true)
        {
            turnGreen();
            flashWhite = false;
            flashDelay = Time.time + 0.5f;
        }
        if(Time.time > flashDelay && flashWhite == false && shouldFlash == true)
        {
            turnWhite();
            flashWhite = true;
            flashDelay = Time.time + 0.5f;
        }*/
    }
    void turnGreen()
    {
        myRend.material = green;
    }

    void turnWhite()
    {
        myRend.material = white;
    }

    void turnRed()
    {
        myRend.material = red;
    }

    void turnBlue()
    {
        myRend.material = blue;
    }

    public void setShouldFlash()
    {
        if(shouldFlash == false)
        {
            shouldFlash = true;
            Instantiate(myWarpSound);
            gameObject.GetComponent<ParticleSystem>().Play();
        }
    }
        
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Mage" && shouldFlash == true)
        {
            //Instantiate(myWarpSound);

            if (sceneStory != null)
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                sceneStory.SetActive(true);
            }
            else
            {
                loadingScreen.SetActive(true);
            }
            //SceneManager.LoadScene("FirePlanet");

        }
    }
}