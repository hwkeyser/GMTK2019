using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class calcScore : MonoBehaviour
{
    public GameObject Player;
    public GameObject Goal;

    public void GetScore()
    {
        float dist = Vector3.Distance(Player.transform.position, Goal.transform.position);
        GetComponent<Text>().text = dist.ToString("0") + " Meters";
    }

}
