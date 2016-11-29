using UnityEngine;
using System.Collections;

public class BetweenLevel : MonoBehaviour {

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
        transform.gameObject.SetActive(false);
        Cursor.visible = false;
        loadingScreen.SetActive(true);
	}
}
