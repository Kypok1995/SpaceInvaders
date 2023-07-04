using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    public int maxLives = 3;//amount of lifes for the player
    public TMP_Text livesText;//text to write amount of lifes

    private int currentLives;//current amount of lifes
    public AudioClip playerDeathSound;
    public AudioClip playerCollisionSound;
    private AudioSource playerAudio;



    private void Start()
    {
        playerAudio = GetComponent<AudioSource>();
        currentLives = maxLives;//set maximum lifes on the start
        UpdateLivesText();//show them at text object
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the player collided with an enemy projectile
        if (collision.gameObject.CompareTag("Projectile"))
        {
            // Reduce a life
            currentLives--;
            playerAudio.PlayOneShot(playerCollisionSound); //to play a sound over collision
            UpdateLivesText();

            // Check if the player is out of lives
            if (currentLives <= 0)
            {
                PlayerGameOver();
            }

            Destroy(collision.gameObject);//to destroy enemy projectile upon collision

        }
    }

    private void UpdateLivesText()//show amount of current lifes
    {
        livesText.text = "Lives: " + currentLives.ToString();
    }

    private void PlayerGameOver()
    {
        livesText.text = "YOU ARE DEAD!";

        if(playerAudio != null)
        {
            playerAudio.PlayOneShot(playerDeathSound);//to play audio sound on death
        }
        else
        {
            Debug.Log("Audio Clip is not playing!");
        }

        SceneManager.LoadScene("Invaders_Restart");//if player is death - load a restart scene



    }

  

}
