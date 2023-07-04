using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invaders_EnemySpawn : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float movementSpeed = 5f;        // Speed at which the enemies move
    public int minGroupSize = 1;            // Minimum number of enemies in a group
    public int maxGroupSize = 2;            // Maximum number of enemies in a group
    public float spawnDelay = 10f;           // Delay between enemy group spawns
    public float initialSpawnDelay = 5f;    // Delay before the first enemy group spawns


    private void Start()
    {
        InvokeRepeating("SpawnEnemyGroup", initialSpawnDelay, spawnDelay);//to continiously spawn an enemies
    }


    private void SpawnEnemyGroup()
    {
        int groupSize = Random.Range(minGroupSize, maxGroupSize + 1);//to make enemies group random size

        for (int i = 0; i < groupSize; i++)
        {
            
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        }
    }
}
