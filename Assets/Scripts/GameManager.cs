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
    private int coins = 0;
    private int highScore;
    private const string highScoreKey = "HighScore";

    // UI
    public Text scoreText;
    public GameObject resetButton;
    public Text coinText;
    public Text highscoreText;

    //Powerups
    public PowerupManager powerupManager;
    public Battery battery;
    public Magnet magnet;

    private void Start()
    {
        battery = powerupManager.Battery;
        magnet = powerupManager.Magnet;
        //PlayerPrefs.DeleteAll();
        battery.isActive = false;
        magnet.isActive = false;

        coins = PlayerPrefs.GetInt("Coins");
        coinText.text = coins.ToString();

        highScore = PlayerPrefs.GetInt(highScoreKey, 0);

        //SceneManager.sceneUnloaded += s => { print("test"); PlayerPrefs.SetInt(highScoreKey, highScore); }; 
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt(highScoreKey, highScore);
    }

    private void FixedUpdate()
    {
        score += worldScrollingSpeed;
        if(score > highScore)
        {
            highScore = (int)score;
        }

        scoreText.text = score.ToString("0");
        highscoreText.text = highScore.ToString();
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        resetButton.SetActive(true);
        PlayerPrefs.SetInt(highScoreKey, highScore);
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void CoinCollected()
    {
        coins++;
        coinText.text = coins.ToString();
        PlayerPrefs.SetInt("Coins", coins);
    }

    internal void BatteryCollected()
    {
        battery.isActive = true;
        worldScrollingSpeed += battery.speedBoost;

        Invoke(nameof(CancelBattery), battery.duration);
    }

    private void CancelBattery()
    {
        battery.isActive = false;
        worldScrollingSpeed -= battery.speedBoost;
    }

    public void MagnetCollected()
    {
        if(magnet.isActive)
        {
            CancelInvoke(nameof(CancelMagnet));
        }

        magnet.isActive = true;

        Invoke(nameof(CancelMagnet), magnet.duration);
    }

    private void CancelMagnet()
    {
        magnet.isActive = false;
    }
}
