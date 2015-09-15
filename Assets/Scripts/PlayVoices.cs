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
		AudioSource audioSource = GameObject.FindGameObjectWithTag("bvoice").GetComponent<AudioSource> ();
		audioSource.clip = badGoLeft;
		audioSource.Play();
       
    }

    public void PlayBadGoRight()
    {
		AudioSource audioSource = GameObject.FindGameObjectWithTag("bvoice").GetComponent<AudioSource> ();
		audioSource.clip = badGoRight;
		audioSource.Play();
        
    }

    public void PlayBadKeepGoing()
    {
		AudioSource audioSource = GameObject.FindGameObjectWithTag("bvoice").GetComponent<AudioSource> ();
		audioSource.clip = badKeepGoing;
		audioSource.Play();

    }

    public void PlayBadStopStopStop()
    {
		AudioSource audioSource = GameObject.FindGameObjectWithTag("bvoice").GetComponent<AudioSource> ();
		audioSource.clip = badStopStopStop;
		audioSource.Play();

    }

    public void PlayBadNoNoNo()
    {
		AudioSource audioSource = GameObject.FindGameObjectWithTag("bvoice").GetComponent<AudioSource> ();
		audioSource.clip = badNoNoNo;
		audioSource.Play();

    }

    public void PlayBadHaha()
    {
		AudioSource audioSource = GameObject.FindGameObjectWithTag("bvoice").GetComponent<AudioSource> ();
		audioSource.clip = badHaha;
		audioSource.Play();

    }

    public void PlayBadGoBack()
    {
		AudioSource audioSource = GameObject.FindGameObjectWithTag("bvoice").GetComponent<AudioSource> ();
		audioSource.clip = badGoBack;
		audioSource.Play();

    }

    public void PlayBadComeThisWay()
    {
		AudioSource audioSource = GameObject.FindGameObjectWithTag("bvoice").GetComponent<AudioSource> ();
		audioSource.clip = badComeThisWay;
		audioSource.Play();

    }
    
    public void PlayGoodGoLeft()
    {
		AudioSource audioSource = GameObject.FindGameObjectWithTag("gvoice").GetComponent<AudioSource> ();
		audioSource.clip = goodGoLeft;
		audioSource.Play();

    }

    public void PlayGoodGoRight()
    {
		AudioSource audioSource = GameObject.FindGameObjectWithTag("gvoice").GetComponent<AudioSource> ();
		audioSource.clip = goodGoRight;
		audioSource.Play();

    }

    public void PlayGoodKeepGoing()
    {
		AudioSource audioSource = GameObject.FindGameObjectWithTag("gvoice").GetComponent<AudioSource> ();
		audioSource.clip = goodKeepGoing;
		audioSource.Play();

    }

    public void PlayGoodStopStopStop()
    {
		AudioSource audioSource = GameObject.FindGameObjectWithTag("gvoice").GetComponent<AudioSource> ();
		audioSource.clip = goodStopStopStop;
		audioSource.Play();

    }

    public void PlayGoodNoNoNo()
    {
		AudioSource audioSource = GameObject.FindGameObjectWithTag("gvoice").GetComponent<AudioSource> ();
		audioSource.clip = goodNoNoNo;
		audioSource.Play();

    }

    public void PlayGoodHaha()
    {
		AudioSource audioSource = GameObject.FindGameObjectWithTag("gvoice").GetComponent<AudioSource> ();
		audioSource.clip = goodHaha;
		audioSource.Play();

    }

    public void PlayGoodGoBack()
    {
		AudioSource audioSource = GameObject.FindGameObjectWithTag("gvoice").GetComponent<AudioSource> ();
		audioSource.clip = goodGoBack;
		audioSource.Play();
	
    }

    public void PlayGoodComeThisWay()
    {
		AudioSource audioSource = GameObject.FindGameObjectWithTag("gvoice").GetComponent<AudioSource> ();
		audioSource.clip = goodComeThisWay;
		audioSource.Play();

        
    }
    
    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}
}
