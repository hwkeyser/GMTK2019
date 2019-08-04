using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraShake : MonoBehaviour
{
    public float waitTime = .01f;
    private GameObject Camera;
    public float rotateSpeed = 10f;
    

    // Start is called before the first frame update
    void Start()
    {
        Camera = GameObject.FindWithTag("MainCamera");
        StartCoroutine("translate");
        StartCoroutine("rotate");
    }

    IEnumerator translate()
    {
        Camera.transform.position += new Vector3(0, .3f, 0); 
        yield return new WaitForSecondsRealtime(waitTime);
        Camera.transform.position += new Vector3(0, .2f, 0);
        yield return new WaitForSecondsRealtime(waitTime);
        Camera.transform.position += new Vector3(0, .1f, 0);
        yield return new WaitForSecondsRealtime(waitTime);
        Camera.transform.position += new Vector3(0, -.1f, 0);
        yield return new WaitForSecondsRealtime(waitTime);
        Camera.transform.position += new Vector3(0, -.2f, 0);
        yield return new WaitForSecondsRealtime(waitTime);
        Camera.transform.position += new Vector3(0, -.3f, 0);
        yield return new WaitForSecondsRealtime(waitTime);

        Camera.transform.position += new Vector3(0, .1f, 0); 
        yield return new WaitForSecondsRealtime(waitTime);
        Camera.transform.position += new Vector3(0, .2f, 0);
        yield return new WaitForSecondsRealtime(waitTime);
        Camera.transform.position += new Vector3(0, .3f, 0);
        yield return new WaitForSecondsRealtime(waitTime);
        Camera.transform.position += new Vector3(0, -.3f, 0);
        yield return new WaitForSecondsRealtime(waitTime);
        Camera.transform.position += new Vector3(0, -.2f, 0);
        yield return new WaitForSecondsRealtime(waitTime);
        Camera.transform.position += new Vector3(0, -.1f, 0);
        yield return new WaitForSecondsRealtime(waitTime);


    }

    IEnumerator rotate()
    {
        Camera.transform.eulerAngles = Vector3(0, 0, 0);
        yield return new WaitForSecondsRealtime(waitTime);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
