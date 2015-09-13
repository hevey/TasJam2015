using UnityEngine;
using System.Collections;

public class footsteps : MonoBehaviour {

    public void play()
    {
		AudioSource audio = GameObject.FindGameObjectWithTag ("footsteps").GetComponent<AudioSource> ();
		audio.Play ();
	}
	public void stop()
    {
        AudioSource audio = GameObject.FindGameObjectWithTag("footsteps").GetComponent<AudioSource>();
        audio.Stop();

    }
}
