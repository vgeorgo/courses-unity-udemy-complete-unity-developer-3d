using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] Transform head;
    [SerializeField] Transform enemy;
    
    void Update()
    {
        head.LookAt(enemy);
    }
}
