using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] int towerLimit = 5;
    [SerializeField] Tower towerPrefab = null;
    [SerializeField] Transform parent = null;

    Queue<Tower> towerQueue = new Queue<Tower>();

    public void AddTower(Waypoint baseWaypoint)
    {
        if(towerQueue.Count < towerLimit)
            InstantiateNewTower(baseWaypoint);
        else
            MoveExistingTower(baseWaypoint);
    }

    void MoveExistingTower(Waypoint baseWaypoint)
    {
        var oldTower = towerQueue.Dequeue();
        oldTower.SetWaypoint(baseWaypoint);
        towerQueue.Enqueue(oldTower);
    }

    void InstantiateNewTower(Waypoint baseWaypoint)
    {
        var tower = Instantiate(towerPrefab, baseWaypoint.transform.position, Quaternion.identity);
        tower.transform.parent = parent;
        tower.SetWaypoint(baseWaypoint);
        towerQueue.Enqueue(tower);
    }


}
