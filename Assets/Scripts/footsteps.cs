using UnityEngine;
using System.Collections;

public class footsteps : MonoBehaviour {
	//http://www.soundjay.com/footsteps-1.html  footstep audio source
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
