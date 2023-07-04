using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invaders_ProjectileManager : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))//to destroy projectile after colliding with Obstacle
        {
            Destroy(gameObject);
        }

        else if (collision.gameObject.CompareTag("Missle"))//if projectiles collide together - both detoyed
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
