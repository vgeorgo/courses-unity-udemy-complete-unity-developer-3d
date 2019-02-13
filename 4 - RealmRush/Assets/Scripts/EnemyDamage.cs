using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] Collider collisionMesh;
    [SerializeField] int hitPoints = 10;
    [SerializeField] ParticleSystem hitParticlePrefab = null;
    [SerializeField] ParticleSystem deathParticlePrefab = null;
    [SerializeField] AudioClip damageSfx = null;
    [SerializeField] AudioClip deathSfx = null;

    AudioSource audioSource = null;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
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
        hitParticlePrefab.Play();
        audioSource.PlayOneShot(damageSfx);
    }

    void Kill()
    {
        var vfx = Instantiate(deathParticlePrefab, transform.position, Quaternion.identity);
        Destroy(vfx.gameObject, vfx.main.duration);
        AudioSource.PlayClipAtPoint(deathSfx, Camera.main.transform.position);
        Destroy(gameObject);
    }
}
