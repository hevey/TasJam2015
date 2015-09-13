using UnityEngine;
using System.Collections;

public class PlayVoices : MonoBehaviour {

    public AudioClip badGoLeft;
    public AudioClip badGoRight;
    public AudioClip badKeepGoing;
    public AudioClip badStopStopStop;
    public AudioClip badNoNoNo;
    public AudioClip badHaha;
    public AudioClip badGoBack;
    public AudioClip badComeThisWay;
    public AudioClip goodGoLeft;
    public AudioClip goodGoRight;
    public AudioClip goodKeepGoing;
    public AudioClip goodStopStopStop;
    public AudioClip goodNoNoNo;
    public AudioClip goodHaha;
    public AudioClip goodGoBack;
    public AudioClip goodComeThisWay;

    private void PlayFromPath(AudioClip clip)
    {
        AudioSource audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = clip;
        audioSource.Play();
    }

    public void PlayBadGoLeft()
    {
       PlayFromPath(badGoLeft);
    }

    public void PlayBadGoRight()
    {
        PlayFromPath(badGoRight);
    }

    public void PlayBadKeepGoing()
    {
        PlayFromPath(badKeepGoing);
    }

    public void PlayBadStopStopStop()
    {
        PlayFromPath(badStopStopStop);
    }

    public void PlayBadNoNoNo()
    {
        PlayFromPath(badNoNoNo);
    }

    public void PlayBadHaha()
    {
        PlayFromPath(badHaha);
    }

    public void PlayBadGoBack()
    {
        PlayFromPath(badGoBack);
    }

    public void PlayBadComeThisWay()
    {
        PlayFromPath(badComeThisWay);
    }
    
    public void PlayGoodGoLeft()
    {
        GameObject.FindGameObjectWithTag("gvoice");
        PlayFromPath(goodGoLeft);
    }

    public void PlayGoodGoRight()
    {
        PlayFromPath(goodGoRight);
    }

    public void PlayGoodKeepGoing()
    {
        PlayFromPath(goodKeepGoing);
    }

    public void PlayGoodStopStopStop()
    {
        PlayFromPath(goodStopStopStop);
    }

    public void PlayGoodNoNoNo()
    {
        PlayFromPath(goodNoNoNo);
    }

    public void PlayGoodHaha()
    {
        PlayFromPath(goodHaha);
    }

    public void PlayGoodGoBack()
    {
        PlayFromPath(goodGoBack);
    }

    public void PlayGoodComeThisWay()
    {
        PlayFromPath(goodComeThisWay);
    }
    
    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}
}
