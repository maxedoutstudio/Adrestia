using UnityEngine;
using System.Collections;

public class buttonScript : MonoBehaviour 
{
    public GameObject loadingScreen;
    public AudioSource startSound;
    AudioSource myStartSound;

    void Start()
    {
        myStartSound = startSound.GetComponent<AudioSource>();
    }

    public void play()
	{
        Instantiate(myStartSound);
        loadingScreen.SetActive(true);
	}
}
