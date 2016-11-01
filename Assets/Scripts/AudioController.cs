using UnityEngine;
using System.Collections;

public class AudioController : MonoBehaviour {

    public AudioClip[] sounds;

    AudioSource source;

	// Use this for initialization
	void Start () {
        source = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {

        // Checks to play ambient music
        if (!source.isPlaying)
        {
            // Random selects ambient sound to play
            AudioClip sound = sounds[Random.Range(0, sounds.Length)];

            source.clip = sound;
            source.Play();
            //source.transform.position = transform.position;
            //AudioSource.PlayClipAtPoint(sound, transform.position);
        }

    }
}
