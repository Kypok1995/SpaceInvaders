using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Invaders_ExitButton : MonoBehaviour
{

    public Button exitButton; // Reference to the UI button
    private void Start()
    {
        exitButton.onClick.AddListener(ExitGame);
    }
    private void ExitGame()
    {
        // Exit the game
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
