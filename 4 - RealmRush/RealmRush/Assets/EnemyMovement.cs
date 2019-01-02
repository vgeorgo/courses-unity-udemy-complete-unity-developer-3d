using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] List<Block> path;

    void Start()
    {
        
    }
    
    void Update()
    {
        
    }

    protected void PrintWaypoints()
    {
        foreach (Block waypoint in path)
            print(waypoint.name);
    }
}
