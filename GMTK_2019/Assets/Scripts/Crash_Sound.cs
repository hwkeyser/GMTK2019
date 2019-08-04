using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crash_Sound : MonoBehaviour
{

    public AudioClip impact;
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        //if(collision.collider.tag=="Ground")
        //{
            audioSource.PlayOneShot(impact, 0.6f);
        //}
    }
}
