using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public GameObject theShip;
    private float camToShipDis;
    public float disMultiplier;
    public GameObject Camera;
    private Vector3 lerp;

    // Start is called before the first frame update
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Camera = GameObject.FindWithTag("MainCamera");
        //Camera.GetComponent<Camera>().orthographicSize = Mathf.Round(camToShipDis);
    }

    void FixedUpdate()
    {
        camToShipDis = Vector3.Distance(transform.position, theShip.transform.position);
        transform.position = Vector3.Lerp(transform.position + new Vector3(0,1,-1), theShip.transform.position + new Vector3(0, 0, -1), camToShipDis * Time.deltaTime * disMultiplier);
        //Camera.transform.eulerAngles = theShip.transform.eulerAngles;
        transform.LookAt(theShip.transform);
    }
}