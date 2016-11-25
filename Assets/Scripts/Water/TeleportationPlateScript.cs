using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TeleportationPlateScript : MonoBehaviour 
{
    public Material red;
    public Material white;
    public Material green;
    public Material blue;

    Renderer myRend;

    float flashDelay;
    bool flashWhite;
    bool shouldFlash;

    public AudioSource warpSound;
    AudioSource myWarpSound;

    void Start()
    {
        myWarpSound = warpSound.GetComponent<AudioSource>();

        myRend = GetComponent<Renderer>();
        flashDelay = Time.time + 0.5f;
        flashWhite = true;
        shouldFlash = true;
    }

    void Update()
    {
        if(Time.time > flashDelay && flashWhite == true && shouldFlash == true)
        {
            turnWhite();
            flashWhite = false;
            flashDelay = Time.time + 0.5f;
        }
        if(Time.time > flashDelay && flashWhite == false && shouldFlash == true)
        {
            turnGreen();
            flashWhite = true;
            flashDelay = Time.time + 0.5f;
        }
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
        
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Mage")
        {
            Instantiate(myWarpSound);
            SceneManager.LoadScene("FirePlanet");
        }
    }
}