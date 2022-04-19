using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesSpawn : MonoBehaviour
{
    Transform Spawn;
    public GameObject Obstacle;

    void Start()
    {
        Spawn = GameObject.Find("ObstacleSpawn").transform;
    }
 void OnTriggerEnter(Collider col)
 {
   if(col.gameObject.CompareTag("Obstacle"))
   {
     Destroy(col.gameObject);

     Instantiate(Obstacle, Spawn.position, Spawn.rotation);
   } 
 }
}
