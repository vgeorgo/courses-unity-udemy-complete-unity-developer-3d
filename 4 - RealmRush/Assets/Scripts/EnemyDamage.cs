using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] Collider collisionMesh;
    [SerializeField] int hitPoints = 10;

    void Start()
    {
        
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if (hitPoints <= 0)
            Kill();
    }

    void ProcessHit()
    {
        hitPoints -= 1;
    }

    void Kill()
    {
        Destroy(gameObject);
    }
}
