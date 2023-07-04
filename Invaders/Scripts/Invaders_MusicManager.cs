using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]//to be able to see in the pannel
public class SceneMusic
{
    public string sceneName; // Name of the scene
    public AudioClip musicClip; // Music clip to play for the scene
}

public class Invaders_MusicManager : MonoBehaviour
{
    public static Invaders_MusicManager Instance;
    public SceneMusic[] sceneMusics; // Array of SceneMusic objects

    private AudioSource audioSource; // Reference to the AudioSource component


    // Start is called before the first frame update
    void Start()
    {

        audioSource = GetComponent<AudioSource>();//link audisource variable
        SceneManager.sceneLoaded += OnSceneLoaded;
        PlaySceneMusic(SceneManager.GetActiveScene().name);//pass the name of current scene

    }


    private void Awake()
    {
        // Ensure only one instance of MusicManager exists. singleton concept
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        PlaySceneMusic(scene.name);//passing name of current scene 
    }

    private void PlaySceneMusic(string sceneName)//main method to find a scene and correspondent music in the Scene Music class
    {
        foreach (SceneMusic sceneMusic in sceneMusics)//find propriate scene Music in the array
        {
            if (sceneMusic.sceneName == sceneName)
            {
                audioSource.Stop();//stop previous one
                audioSource.clip = sceneMusic.musicClip; //choose apropriate music clip
                audioSource.Play();//play it
                return;
            }
        }

        Debug.LogWarning("No music clip assigned for scene: " + sceneName);
    }

    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }




}
