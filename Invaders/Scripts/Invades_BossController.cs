using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Invades_BossController : Invaders_EnemyBehaviour
{
    public Transform[] firePoints; // The transforms representing the positions to spawn the projectiles

    public int maxHP = 20; // Maximum HP of the boss
    private int currentHP; // Current HP of the boss
    public bool bossDefeated;


    public TMP_Text hpText; // Reference to the TextMeshPro text component

    // Start is called before the first frame update
    void Start()
    {
        bossDefeated = false;//at the start boss is not defeated
        int timeBetweenShoots = Random.Range(2, 4);
        currentHP = maxHP;
        originalY = transform.position.y;
        InvokeRepeating("MultipleShoot", shootDelay,(float)(Random.Range(2,4)));//to make a shoots every random 2-4 seconds
        UpdateHPText();
    }

    // Update is called once per frame
    void Update()
    {
        MoveEnemies();
    }

    private void MultipleShoot()
    {
        // Spawn projectiles at the specified fire points
        foreach (Transform firePoint in firePoints)
        {
            // Create the projectile
            GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);//to instantiate new projectile
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)//in case of collision with missle
    {
        Invaders_ScoreCounter scoreCounter = FindObjectOfType<Invaders_ScoreCounter>();//to find an ScoreCounter in the Game
        if (collision.gameObject.CompareTag("Missle"))
        {
            // Reduce HP by 1
            currentHP--;
            UpdateHPText();//shows new HP in his HP bar
            Debug.Log("- 1hp");

            // Check if the boss is defeated
            if (currentHP <= 0)
            {
                Debug.Log("Boss defeated");
                bossDefeated = true;//boss now is defeated
                scoreCounter.ShowWinScene();
                Destroy(gameObject);//game object no longer exist
            }
        }
    }

    private void UpdateHPText()//shows hp of the boss
    {
        if (hpText != null)
        {
            hpText.text = "Boss HP: " + currentHP.ToString();
        }
    }



}
