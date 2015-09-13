using UnityEngine;
using System.Collections;

public class PlayVoices : MonoBehaviour {
    
    string goodGoLeftPath = "";
    string goodGoRightPath = "";
    string goodKeepGoingPath = "";
    string goodStopStopStopPath = "";

    private void PlayFromPath(string path)
    {
        AudioSource audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = Resources.Load(path) as AudioClip;
        audioSource.Play();
    }

    public void PlayGoodGoLeft()
    {
        PlayFromPath(goodGoLeftPath);
    }

    public void PlayGoodGoRight()
    {
        PlayFromPath(goodGoRightPath);
    }

    public void PlayGoodKeepGoing()
    {
        PlayFromPath(goodKeepGoingPath);
    }

    public void PlayGoodStopStopStop()
    {
        PlayFromPath(goodStopStopStopPath);
    }


    //    Go Left
    //Go Right
    //KeepGoing
    //STOPSTOPSTOP
    //You are almost there
    //NO NO NO Don’t listen to him
    //HA HA HA HA HA HA
    //Go Back
    //Come This way
    // Use this for initialization
    void Start () {
        //  Load voices into memory
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
