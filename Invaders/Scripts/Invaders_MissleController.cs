using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invaders_MissleController : MonoBehaviour//script should be hold on the missleSpawnerPoint 
{
    public GameObject missilePrefab; // Prefab of the missile object
    public Transform missileSpawnPoint; // Point where the missile will be spawned
    public float missileSpeed = 10f; // Speed of the missile
    public float shootCooldown = 0.5f; // Cooldown period between shots

    private float shootTimer = 0f; // Timer to track cooldown


    void Update()
    {
        shootTimer -= Time.deltaTime; // Decrease the shootTimer based on elapsed time

        if (Input.GetKeyDown(KeyCode.Space) && shootTimer <= 0f) //missles are shoot only than player press space
        {
            ShootMissile();
            shootTimer = shootCooldown; // Reset the shootTimer to the cooldown value
        }
    }

    void ShootMissile()
    {
        GameObject missile = Instantiate(missilePrefab, missileSpawnPoint.position, Quaternion.identity); //to create a missle after pressing space
        Rigidbody2D missileRb = missile.GetComponent<Rigidbody2D>(); 
        missileRb.velocity = transform.up * missileSpeed; //add power to the missle to go up
    }

}
