using UnityEngine;
using System.Collections;

public class EndZone : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.transform.name == "Mage")
        {
            GameObject.Find("warpGate").GetComponent<TeleportationPlateScript>().setShouldFlash();
        }
    }
}
