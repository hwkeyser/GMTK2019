using UnityEngine;
using System.Collections;

public class DestroyEffect : MonoBehaviour {

	void Update ()
	{

		if(Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.C))
		   Destroy(transform.gameObject);
        GetComponent<Rigidbody>().velocity = new Vector3(0, -20, 400);
    }
}
