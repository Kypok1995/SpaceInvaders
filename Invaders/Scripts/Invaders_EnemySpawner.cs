using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invaders_EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;//hold an enemy prefab
    public GameObject bossPrefab;//hold a prefab of the boss

    public float spawnInterval = 10f;//time between enemy spawn

    private float timer = 0f;


    private void Start()
    {
    }

    private void Update()
    {
        // Increment the timer
        timer += Time.deltaTime;

        if (timer >= spawnInterval && GameObject.FindGameObjectsWithTag("Enemy").Length < 3)//if there are less than 3 enemies in the game
        {
            SpawnEnemy();
            timer = 0f;
        }
    }
    


    private void SpawnEnemy()
    {
        Invaders_ScoreCounter scoreCounter = FindObjectOfType<Invaders_ScoreCounter>();//to a find a score counter in the scene and access it's score
                                                                                       // Generate a random position within the small radius
        Vector3 spawnPosition = transform.position + Random.insideUnitSphere;

        Vector2 bossSpawnPosition = new Vector2(5, 25);

        if (scoreCounter.enemiesDefeated == false)//to spawn usual enemy if 
        {

            // Instantiate the enemy at the spawn position
            GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        }

        else//to spawn boss
        {
            if (GameObject.FindGameObjectWithTag("GameBoss") == null && GameObject.FindObjectsOfType<Invaders_EnemyBehaviour>().Length == 0)//if no other boss and other enemies in the game
            {
                GameObject boss = Instantiate(bossPrefab, bossSpawnPosition, Quaternion.identity);
            }

        }

    }
}
