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
    public bool GameStart;
    public bool GamePaused;
    public bool GameOver;


    private Rigidbody rb;           // Our Rigidbody.

    void Start()
    {
        GameStart = false;
        GamePaused = false;
        GameOver = false;
        rb = GetComponent<Rigidbody>();        // Gets the players Rigidbody.
        
        Time.timeScale = 0;
    }



    void FixedUpdate()
    {
        if (GameStart && !GamePaused && !GameOver)
        {
            //refresh current speed
            currentSpeed = Mathf.Abs(rb.velocity.z) + Mathf.Abs(rb.velocity.x);

            //Thrust Forward
            rb.AddRelativeForce(Vector3.forward * currentThrust);

            rb.transform.Rotate(0, Yaw / 10, 0, Space.Self);

            changeThrust();
            turningInputs();
        }
        if (GamePaused || GameOver)
        {
            Time.timeScale = 0;
        }

    }

    public void StartGame()
    {
        GameStart = true;
        GameOver = false;
        Time.timeScale = 1;
        rb.velocity = new Vector3(0, 0, startSpeed);
        RollAmount = rb.transform.rotation.x;
    }

    private void turningInputs()
    {
        if (GameStart && !GamePaused && !GameOver)
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                Yaw = Mathf.Clamp(Yaw + Input.GetAxis("Horizontal"), -1.5f, 0);
            }
            else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                Yaw = Mathf.Clamp(Yaw + Input.GetAxis("Horizontal"), -1f, 0);
            }
            else
            {
                Yaw = -.3f;
            }
        }
    }



    private void changeThrust()
    {
        if (GameStart && !GamePaused && !GameOver)
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
}
