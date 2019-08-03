﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    // it may make more sense to do "[SerializeField]" as i dont think this needs to be called from anywhere. we just need to edit the feilds from 

    public float maxSpeed;          // Our maximum speed allowed.
    public float decAltSpeed;       // Decrease Altitude.
    public float incAltSpeed;       // Increase Altitude.
    public float currentSpeed;      // Current Speed;
    public float thrust;            // How much force to apply (Forward).
    public float airBrakeForce;     // Breaks.
    public float bank;

    private Rigidbody rb;           // Our Rigidbody.

    void Start()
    {
        rb = GetComponent<Rigidbody>();        // Gets the players Rigidbody.
    }

    void FixedUpdate()
    {

        currentSpeed = rb.velocity.z;

        if (currentSpeed >= maxSpeed)
        {
            //If our speed maxes out to our maxSpeed we restrict our plane from going any faster.
            thrust = currentSpeed;
        }

        // can add later if needs to just start off the back remove the get key down for W
        // rb.AddForce(new Vector3(transform.forward.x, 0, transform.forward.z) * thrust); 
        if (Input.GetKey(KeyCode.W))
        {
            //Apply Accelleration
            rb.AddRelativeForce(Vector3.forward * thrust);
            if (currentSpeed >= incAltSpeed)
            {
                rb.AddRelativeForce(Vector3.up * 10);
            }

        }
        if (Input.GetKey(KeyCode.S))
        {
            //Apply airBrakeForce
            rb.AddRelativeForce(Vector3.back * airBrakeForce);
            if (currentSpeed <= decAltSpeed)
            {
                rb.AddRelativeForce(Vector3.down * 10);
            }
        }

    }


    void Update()
    {
        //NOT REALISTIC ROTATIONS but not trying to be REALISTIC at this stage.

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(-Vector3.up * 15 * Time.deltaTime);

        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up * 15 * Time.deltaTime);

        }
    }

}