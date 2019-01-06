using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    Queue<Waypoint> queue = new Queue<Waypoint>();
    Vector2Int[] directions = { Vector2Int.up, Vector2Int.right, Vector2Int.down, Vector2Int.left };
    bool isRunning = true;
    List<Waypoint> path = new List<Waypoint>();
    Waypoint searchCenter;

    [SerializeField] Waypoint startWaypoint = null, endWaypoint = null;

    public List<Waypoint> GetPath()
    {
        LoadWaypoints();
        ColorStartAndEnd();
        BreadthFirstSearch();
        CreatePath();
        return path;
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

    void BreadthFirstSearch()
    {
        EnqueueWaypoint(startWaypoint);
        while(queue.Count > 0 && isRunning)
        {
            searchCenter = DequeueWaypoint();
            HaltIfEndFound(searchCenter);
            if (isRunning)
                ExploreNeighbours();
        }
    }

    void HaltIfEndFound(Waypoint exploreWaypoint)
    {
        if (exploreWaypoint == endWaypoint)
            isRunning = false;
    }

    void ExploreNeighbours()
    {
        foreach(Vector2Int direction in directions)
        {
            Vector2Int exploreCoordinates = searchCenter.GetGridPos() + direction;
            if(grid.ContainsKey(exploreCoordinates))
                EnqueueWaypoint(grid[exploreCoordinates]);
        }
    }

    void EnqueueWaypoint(Waypoint w)
    {
        if (w.isQueued)
            return;

        w.isQueued = true;
        w.exploredFrom = searchCenter;
        queue.Enqueue(w);
    }

    Waypoint DequeueWaypoint()
    {
        var w = queue.Dequeue();
        return w;
    }

    void CreatePath()
    {
        var w = endWaypoint;

        do
        {
            path.Add(w);
            w = w.exploredFrom;
        }
        while (w != null);

        path.Reverse();
    }
}
