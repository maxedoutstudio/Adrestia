using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class loadFire : MonoBehaviour 
{
    bool load;

    void Start()
    {
        load = false;
    }

    void Update()
    {
        if(load == false)
        {
            load = true;
            SceneManager.LoadScene("FirePlanet");
        }
    }
}
