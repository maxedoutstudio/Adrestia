using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class buttonScript : MonoBehaviour 
{
	public void play()
	{
		SceneManager.LoadScene("Tutorial");
	}
}
