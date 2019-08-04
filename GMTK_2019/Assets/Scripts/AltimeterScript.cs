using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AltimeterScript : MonoBehaviour
{

    public GameObject player;
    private Transform player_transform;
    private GameObject altimeter;


    // Start is called before the first frame update
    void Start()
    {
        player_transform = player.GetComponent<Transform>();
        altimeter = GameObject.Find("Altimeter");
    }

    // Update is called once per frame
    void Update()
    {
        altimeter.GetComponent<Slider>().value = player_transform.position.y;
    }
}
