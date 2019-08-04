using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class Scoring : MonoBehaviour
{
    private GameObject waypointObj;
    public Vector3 WaypointPos;
    
    UnityEvent e_PlaneCrashed;

    // Start is called before the first frame update
    void Start()
    {
        // Get waypoint object via find, temporary... bad practice!
        waypointObj = GameObject.Find("Waypoint");
        WaypointPos = waypointObj.transform.position;

        if (e_PlaneCrashed == null) 
        {
            // Create Unity Event
            e_PlaneCrashed = new UnityEvent();
            e_PlaneCrashed.AddListener(planeCrashedPointsCalc);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Plane has crashed");

        // Use this event to trigger plane crash events
        e_PlaneCrashed.Invoke();
    }

    // Internal function to calculate points
    void planeCrashedPointsCalc()
    {

        // WIP

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(WaypointObj.transform.position);

    }
}
