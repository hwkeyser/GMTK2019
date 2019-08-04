using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetachEngine : MonoBehaviour
{
    // Start is called before the first frame update
    void Update()
    {
        this.transform.parent = null;
        this.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, this.GetComponentInParent<Controls>().startSpeed);
    }



}
