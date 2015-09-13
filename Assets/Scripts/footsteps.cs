using UnityEngine;
using System.Collections;

public class footsteps : MonoBehaviour {

    void play()
    {
        AudioSource audio = GameObject.FindGameObjectWithTag("footsteps").GetComponent<AudioSource>();
        audio.Play();
        audio.Play(44100);
    }

    void stop()
    {
        AudioSource audio = GameObject.FindGameObjectWithTag("footsteps").GetComponent<AudioSource>();
        audio.Stop();

    }
}
