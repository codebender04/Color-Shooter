using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy enemyPrefab;
    [SerializeField] private float spawnCooldown;
    [SerializeField] private float minSpawnTime = 2f;
    [SerializeField] private float maxSpawnTime = 6f;
    private void Start()
    {
        Spawn();
    }
    private void Spawn()
    {
        spawnCooldown = Random.Range(minSpawnTime, maxSpawnTime);
        Instantiate(enemyPrefab, transform.position, transform.rotation);
        Invoke(nameof(Spawn), spawnCooldown);
    }
}
