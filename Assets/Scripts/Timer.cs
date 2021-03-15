using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public AudioClip congrats;
    public AudioSource speaker;

    void Start()
    {
        speaker.PlayOneShot(congrats);
    }

    void Update()
    {
        Invoke("restartGame", 5);
    }

    void restartGame()
    {
        SceneManager.LoadScene(sceneName: "MainMenu");
    }
}

