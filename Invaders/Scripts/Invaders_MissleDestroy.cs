using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invaders_MissleDestroy : MonoBehaviour//this script should be on the missle prefab itself
{
    public float lifetime = 5f; // Time in seconds before the missile disappears
    public AudioClip collisionClip;

    public GameObject particleEffectPrefab;


    void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Enemy"))//destroy both enemy and missile
        {
            
            
            Invaders_ScoreCounter scoreCounter = FindObjectOfType<Invaders_ScoreCounter>();//to find an ScoreCounter in the Game and increase a score
            if (scoreCounter != null)//if it is assigned to gameObject
            {
                scoreCounter.IncreaseScore();
            }

            Invaders_MusicManager.Instance.PlaySound(collisionClip);
            
            // Destroy the enemy and the missile
            Destroy(collision.gameObject);
            //desctoy missile as well
            ShowParticle();//to show particles before desctroying a rocket
            Destroy(gameObject);




        }
        else if (collision.gameObject.CompareTag("Obstacle"))//destroy only missile if it collide with obstacle
        {
            Destroy(gameObject);
        }

        else if (collision.gameObject.CompareTag("GameBoss"))
        {
            Invaders_MusicManager.Instance.PlaySound(collisionClip);
            Destroy(gameObject);//destroy rocket on colliding with boss
        }
    }

    private void ShowParticle()
    {
        GameObject particleEffect = Instantiate(particleEffectPrefab, transform.position, Quaternion.identity); //to instantiate particle effect
        particleEffect.GetComponent<ParticleSystem>().Play();//to make a particle system play
    }
}
