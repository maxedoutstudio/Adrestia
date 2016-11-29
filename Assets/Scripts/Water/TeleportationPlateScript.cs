using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TeleportationPlateScript : MonoBehaviour 
{
    public GameObject loadingScreen;

    Renderer myRend;

    float flashDelay;
    bool flashWhite;
    bool shouldFlash;

    public AudioSource warpSound;
    AudioSource myWarpSound;

    public AudioSource openSound;
    AudioSource myOpenSound;

    public GameObject powerUpTracker;
    PowerupTracker myPowerUpTrackerScript;

    public GameObject sceneStory;

    void Start()
    {
        myOpenSound = openSound.GetComponent<AudioSource>();
        myPowerUpTrackerScript = powerUpTracker.GetComponent<PowerupTracker>();
        myWarpSound = warpSound.GetComponent<AudioSource>();

        myRend = GetComponent<Renderer>();
        flashDelay = Time.time + 0.5f;
        flashWhite = true;
        shouldFlash = false;
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

            Destroy(GameObject.Find("warpSound(Clone)"));

            if (sceneStory != null)
            {
                Instantiate(myOpenSound);
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