using UnityEngine;
using System.Collections;

public class chapterSelectScript : MonoBehaviour 
{
    public GameObject menu1;
    public GameObject menu2;

    public void play()
    {
        menu1.SetActive(false);
        menu2.SetActive(true);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(menu2.activeSelf == true)
            {
                menu2.SetActive(false);
                menu1.SetActive(true);
            }
        }
    }
}
