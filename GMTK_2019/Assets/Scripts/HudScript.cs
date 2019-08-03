using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudScript : MonoBehaviour
{

    private GameObject player;
    private Controls controls;
    private Transform transform;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("_Player");
        controls = player.GetComponent<Controls>();
        transform = player.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        float currentSpeed = controls.currentSpeed;
        float alt = transform.position.y;
        float rot = (transform.rotation.y + 360) % 360;
        int eng = 1;
        Text txt = GetComponent<Text>();
        txt.text = "Speed: " + currentSpeed.ToString("0.000") + "m/s\n";
        txt.text += "Altitude: " + alt.ToString("0.0") + "m\n";
        txt.text += "Direction: " + rot.ToString("0.000") + "°F\n";
        txt.text += "No. Engines: " + eng.ToString();
    }
}
