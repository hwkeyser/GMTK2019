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
        Debug.log("Thrust");
        rb.AddForce(0,0, thrust, ForceMode.Impulse);
    }
}
