using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWorld : MonoBehaviour
{

    public GameObject SpawnZone;
    //public GameObject NoSpawnZone;
    public GameObject Player;
    private Vector3 center;
    private Vector3 size;

    // Start is called before the first frame update
    public void SpawnGame()
    {
        //set center of spawn zone
        center = SpawnZone.transform.position;

        //set size of spawn zone (random X in spawn zone, altitude equal y position , random Z in spawn zone
        Vector3 pos = center + new Vector3(Random.Range(-SpawnZone.transform.localScale.x / 2, SpawnZone.transform.localScale.x / 2), 0, Random.Range(-SpawnZone.transform.localScale.z / 2, SpawnZone.transform.localScale.z / 2));

        //move player position to random spawn point and rotation random on y axis
        Player.transform.SetPositionAndRotation(pos, Quaternion.Euler(0, Random.Range(0, 360), 0));

 
    }
}
