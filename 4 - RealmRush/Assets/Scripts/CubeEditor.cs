using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
[RequireComponent(typeof(Waypoint))]
public class CubeEditor : MonoBehaviour
{
    Waypoint waypoint;

    void Update()
    {
        SnapToGrid();
        UpdateLabel();
    }

    void SnapToGrid()
    {
        waypoint = GetComponent<Waypoint>();
        int gridSize = waypoint.GetGridSize();
        Vector2Int gridPos = waypoint.GetGridPos();

        transform.position = new Vector3(gridPos.x * gridSize, 0f, gridPos.y * gridSize);
    }

    void UpdateLabel()
    {
        TextMesh textMesh = GetComponentInChildren<TextMesh>();
        waypoint = GetComponent<Waypoint>();
        int gridSize = waypoint.GetGridSize();
        Vector2Int gridPos = waypoint.GetGridPos();

        gameObject.name = textMesh.text = gridPos.x + "," + gridPos.y;
    }
}
