using UnityEngine;
using System.Collections;

public class buttonScript : MonoBehaviour 
{
    public GameObject loadingScreen;

    public void play()
	{
        loadingScreen.SetActive(true);
	}
}
