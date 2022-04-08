using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Singleton
    public static GameManager instance;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogError("Multiple GameManagers in the Scene!");
        }
    }

    // Game Settings
    public float worldScrollingSpeed = 0.1f;
    private float score = 0;

    // UI
    public Text scoreText;
    public GameObject resetButton;

    private void FixedUpdate()
    {
        score += worldScrollingSpeed;
        scoreText.text = score.ToString("0");
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        resetButton.SetActive(true);
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
