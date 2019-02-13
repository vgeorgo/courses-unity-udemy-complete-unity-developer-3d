using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    [Range(0.3f, 60f)] [SerializeField] float secondsBetweenSpawns = 2f;
    [SerializeField] EnemyMovement enemyPrefab = null;
    [SerializeField] Text textScore = null;
    [SerializeField] AudioClip spawnSfx = null;

    AudioSource audioSource = null;

    int score = 0;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        UpdateScore();
        StartCoroutine(SpawnEnemies());
    }
    
    IEnumerator SpawnEnemies()
    {
        while(true)
        {
            var enemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            enemy.transform.parent = transform;
            AddScore();
            audioSource.PlayOneShot(spawnSfx);
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }

    void AddScore()
    {
        score++;
        UpdateScore();
    }

    void UpdateScore()
    {
        textScore.text = score.ToString();
    }
}
