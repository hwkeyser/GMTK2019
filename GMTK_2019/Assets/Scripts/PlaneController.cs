using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour

{
    public float thrust;
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //this will push forward without anyone telling. you can edit the speed inside unity play opject pantent. right now its turn off. 
        rb.AddForce(new Vector3(transform.forward.x, 0, transform.forward.z) * thrust); 
    }
}
