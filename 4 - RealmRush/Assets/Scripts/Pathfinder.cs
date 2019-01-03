using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();

    [SerializeField] Waypoint startWaypoint, endWaypoint;

    void Start()
    {
        LoadWaypoints();
        ColorStartAndEnd();
    }

    void Update()
    {
        
    }

    void LoadWaypoints()
    {
        var waypoints = FindObjectsOfType<Waypoint>();
        foreach(Waypoint w in waypoints)
        {
            var gridPos = w.GetGridPos();

            if(grid.ContainsKey(gridPos))
            {
                Debug.LogWarning("Skipping overlapping waypoint " + w);
                continue;
            }

            grid.Add(gridPos, w);
        }
    }

    void ColorStartAndEnd()
    {
        startWaypoint.SetTopColor(Color.green);
        endWaypoint.SetTopColor(Color.red);
    }
}
