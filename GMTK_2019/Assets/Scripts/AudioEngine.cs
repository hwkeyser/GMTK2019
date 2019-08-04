//Attach this script to a GameObject.
//Attach an AudioSource to your GameObject (Click Add Component and go to Audio>Audio Source). Choose an audio clip in the AudioClip field.
//This script sets the pitch of the audio at the start, and then gradually turns it down to 0 as time passes.

using UnityEngine;

//Make sure there is an Audio Source component on the GameObject
[RequireComponent(typeof(AudioSource))]

public class AudioEngine : MonoBehaviour
{
    private GameObject player;
    private Controls controls;

    int startingPitch = 1;
    //int timeToDecrease = 5;
    AudioSource audioSource;

    void Start()
    {
        //Fetch the AudioSource from the GameObject
        audioSource = GetComponent<AudioSource>();

        player = GameObject.Find("_Player");
        controls = player.GetComponent<Controls>();

        //Initialize the pitch
        audioSource.pitch = startingPitch;
    }

    void Update()
    {

        float currentSpeed = controls.currentSpeed;

        //While the pitch is over 0, decrease it as time passes.
        if (audioSource.pitch > 0.5 || audioSource.pitch < 2)
        {
            audioSource.pitch = currentSpeed/200;
        }
    }
}
