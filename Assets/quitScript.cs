using UnityEngine;
using System.Collections;

public class quitScript : MonoBehaviour 
{
    public GameObject menuLoadScreen;

    public void play()
    {
        menuLoadScreen.SetActive(true);
    }
}
