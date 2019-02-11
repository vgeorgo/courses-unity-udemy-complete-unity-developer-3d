using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float delay = 1f;
    [SerializeField] ParticleSystem goalParticlePrefab;

    void Start()
    {
        Pathfinder pathfinder = FindObjectOfType<Pathfinder>();
        StartCoroutine(FollowPath(pathfinder.GetPath()));
    }

    protected IEnumerator FollowPath(List<Waypoint> path)
    {
        foreach (Waypoint waypoint in path)
        {
            transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(delay);
        }

        Kill();
    }

    void Kill()
    {
        var vfx = Instantiate(goalParticlePrefab, transform.position, Quaternion.identity);
        Destroy(vfx.gameObject, vfx.main.duration);
        Destroy(gameObject);
    }
}
