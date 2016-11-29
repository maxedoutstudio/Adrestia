using UnityEngine;
using System.Collections;

public class beginScript : MonoBehaviour {

    public GameObject storyUI;
    public GameObject menu1;

    public AudioSource openMenu;
    AudioSource myOpenMenu;
    public AudioSource closeMenu;
    AudioSource myCloseMenu;

    void Start()
    {
        myOpenMenu = openMenu.GetComponent<AudioSource>();
        myCloseMenu = closeMenu.GetComponent<AudioSource>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(storyUI.activeSelf == true)
            {
                storyUI.SetActive(false);
                menu1.SetActive(true);
                Instantiate(myCloseMenu);
            }
        }
    }

    public void play()
    {
        menu1.SetActive(false);
        storyUI.SetActive(true);
        Instantiate(myOpenMenu);
    }
}
