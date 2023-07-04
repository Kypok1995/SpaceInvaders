using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;

public class Invaders_EnemyBehaviour : MonoBehaviour
{
    public float speed = 2f;
    public float distance = 2f;
    public float originalY;
    private bool moveRight = true;
    private bool moveUp = true;
    public float moveDelay = 2f;
    public float shootDelay = 2f;            // Delay between enemy shots
    public GameObject projectilePrefab;      // Prefab for the enemy projectile
    public Transform projectileSpawnPoint;   // Spawn point for enemy projectiles


    private void Start()
    {
        originalY = transform.position.y;
        InvokeRepeating("Shoot", shootDelay, shootDelay); //to continiously make an enemies shoot
    }

    public void Update()
    {
        MoveEnemies();
    }
    protected void MoveEnemies()//protected in order to give option to use method from Boss script
    {
        // Calculate the new position
        Vector3 newPosition = transform.position;

        // Move horizontally
        if (moveRight)
            newPosition.x += speed * Time.deltaTime;
        else
            newPosition.x -= speed * Time.deltaTime;

        // Move vertically
        if (moveUp)
            newPosition.y += speed * Time.deltaTime;
        else
            newPosition.y -= speed * Time.deltaTime;

        // Update the enemy position
        transform.position = newPosition;

        // Check if the enemy should change direction
        if (transform.position.x >= distance)
            moveRight = false;
        else if (transform.position.x <= -distance)
            moveRight = true;

        if (transform.position.y >= originalY + distance)
            moveUp = false;
        else if (transform.position.y <= originalY - distance)
            moveUp = true;
    }

    private void Shoot()
    {
        GameObject projectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, Quaternion.identity);

    }




}
