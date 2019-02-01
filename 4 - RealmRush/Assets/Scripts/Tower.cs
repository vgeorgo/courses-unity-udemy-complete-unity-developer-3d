using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] Transform head;
    [SerializeField] Transform enemy;
    [SerializeField] float attackRange = 10f;
    [SerializeField] ParticleSystem projectParticle;

    void Update()
    {
        if(enemy)
        {
            head.LookAt(enemy);
            FireAtEnemy();
        }
        else
        {
            Shoot(false);
        }
    }

    void FireAtEnemy()
    {
        float distanceToEnemy = Vector3.Distance(enemy.transform.position, gameObject.transform.position);
        if(distanceToEnemy <= attackRange)
        {
            Shoot(true);
        }
        else
        {
            Shoot(false);
        }
    }

    void Shoot(bool isActive)
    {
        var emissionModule = projectParticle.emission;
        emissionModule.enabled = isActive;
    }
}
