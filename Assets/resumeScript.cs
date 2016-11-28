using UnityEngine;
using System.Collections;

public class resumeScript : MonoBehaviour 
{
    public GameObject menu;

    public void play()
    {
        menu.SetActive(false);
        Cursor.visible = false;
    }
}
