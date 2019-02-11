using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] Transform head = null;
    [SerializeField] float attackRange = 10f;
    [SerializeField] ParticleSystem projectParticle = null;

    [HideInInspector] public Waypoint waypoint = null;

    Transform target = null;

    void Update()
    {
        SetTargetEnemy();
        if (target)
        {
            head.LookAt(target);
            FireAtEnemy();
        }
        else
        {
            Shoot(false);
        }
    }

    void SetTargetEnemy()
    {
        var sceneEnemies = FindObjectsOfType<EnemyDamage>();
        if (sceneEnemies.Length == 0)
            return;

        target = sceneEnemies[0].transform;
        foreach(EnemyDamage testDist in sceneEnemies)
        {
            target = TestDistance(target, testDist.transform);
        }
    }

    protected Transform TestDistance(Transform t1, Transform t2)
    {
        var d1 = Vector3.Distance(transform.position, t1.position);
        var d2 = Vector3.Distance(transform.position, t2.position);
        return d1 < d2 ? t1 : t2;
    }

    void FireAtEnemy()
    {
        float distanceToEnemy = Vector3.Distance(target.transform.position, gameObject.transform.position);
        if (distanceToEnemy <= attackRange)
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

    public void SetWaypoint(Waypoint w)
    {
        if (this.waypoint != null)
            this.waypoint.isPlaceable = true;

        this.waypoint = w;
        w.isPlaceable = false;

        transform.position = w.transform.position;
    }
}
