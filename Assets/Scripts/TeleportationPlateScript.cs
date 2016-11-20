using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TeleportationPlateScript : MonoBehaviour 
{
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Mage")
        {
            SceneManager.LoadScene("FirePlanet");
        }
    }
}