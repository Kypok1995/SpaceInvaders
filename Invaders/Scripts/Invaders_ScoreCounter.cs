using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Invaders_ScoreCounter : MonoBehaviour
{
    public TMP_Text scoreText;//to assign certain text field in the game

    private int score = 0;//initial score

    public int winningScore;
    public bool enemiesDefeated;//to show show what all usual enemies are deleted and it is time for the boss

    private void Start()
    {
        UpdateScoreText();
        enemiesDefeated= false;//not all enemies are defeated
    }

    private void Update()
    {
    }

    public void IncreaseScore()//this script works with MissleDestroy script - triggered on collision with Enemy
    {
        score++;
        UpdateScoreText();

        if(score>= winningScore)
        {
            enemiesDefeated= true;//no more enemies to spawn
        }
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    public void ShowWinScene()
    {
            SceneManager.LoadScene("Invaders_WinScene");//to show go to the win scene
    }
}
