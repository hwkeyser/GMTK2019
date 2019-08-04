using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class liftScript : MonoBehaviour
{
    public float liftMultiplier;
    private float forwardSpeed;
    private float verticalSpeed;
    private float verticalSpeedOffset;
    private float maxSpeed;
    public float liftRatio;
    public float gravity = -9.81f;
    private float lift = 9.81f;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        calculateLift();
        rb.AddForce(0, gravity + lift,0, ForceMode.Acceleration);
    }

    void calculateLift()
    {
        forwardSpeed = GetComponentInParent<Controls>().currentSpeed;
        maxSpeed = GetComponentInParent<Controls>().maxSpeed;
        liftRatio = Mathf.Clamp(forwardSpeed / maxSpeed,0,1);
        lift = liftRatio * liftMultiplier;
    }
}
