using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    // it may make more sense to do "[SerializeField]" as i dont think this needs to be called from anywhere. we just need to edit the feilds from 

    public float startSpeed;        // Start speed for scenario
    public float maxSpeed;          // Our maximum speed allowed.
    public float currentSpeed;      // Current Speed;
    public float maxThrust;         // How much force to apply (Forward).
    public float currentThrust;     // Breaks.
    public float Yaw;
    public float RollAmount;
    public float minThrust;
    public float liftMultplier;
    public float lift;
    public float thrustChangeAmount;


    private Rigidbody rb;           // Our Rigidbody.

    void Start()
    {
        rb = GetComponent<Rigidbody>();        // Gets the players Rigidbody.
        rb.velocity = new Vector3(0, 0, startSpeed);
        RollAmount = rb.transform.rotation.x;
    }

    void FixedUpdate()
    {
        //refresh current speed
        currentSpeed = Mathf.Abs(rb.velocity.z) + Mathf.Abs(rb.velocity.x);

        //Thrust Forward
        rb.AddRelativeForce(Vector3.forward * currentThrust);
        rb.transform.Rotate(0, Yaw / 10, 0, Space.Self);

        changeThrust();
        turningInputs();

    }

    private void turningInputs()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            Yaw = Mathf.Clamp(Yaw + Input.GetAxis("Horizontal"), -1.5f, 0);
            if (RollAmount < 20)
            {
                RollAmount = RollAmount + Input.GetAxis("Horizontal");
                //rb.transform.rotation.y = RollAmount;
            }
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            Yaw = Mathf.Clamp(Yaw + Input.GetAxis("Horizontal"), -1f, 0);
            if (RollAmount > 0)
            {
                RollAmount = RollAmount + Input.GetAxis("Horizontal");
                rb.transform.Rotate(RollAmount, 0, 0, Space.Self);
            }

        }
        //if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        //{
        //    Roll = Mathf.Clamp(Roll - Input.GetAxis("Horizontal"), 0, 20);
        //    rb.transform.Rotate(0, 0, Roll, Space.Self);
        //}
        //if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        //{
        //    Roll = Mathf.Clamp(Roll - Input.GetAxis("Horizontal"), 0, 20);
        //    rb.transform.Rotate(0, 0, -Roll, Space.Self);
        //}
    }



    private void changeThrust()
    {
        if (currentSpeed < maxSpeed)
        {
            if (currentThrust < maxThrust)
            {
                if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
                {
                    //Apply Accelleration
                    currentThrust += thrustChangeAmount;

                }
            }

        }

        // can add later if needs to just start off the back remove the get key down for W
        if (currentSpeed > 0)
        {
            if (currentThrust > minThrust)
            {
                if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
                {
                    //Apply Accelleration
                    currentThrust -= thrustChangeAmount;

                }
            }
        }

    }
}
