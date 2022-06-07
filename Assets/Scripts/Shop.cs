using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public PowerupManager powerupManager;

    public Text coinsText;
    int coins;

    public Text batteryInfoText;
    public Button batteryButton;

    public Text magnetInfoText;
    public Button magnetButton;

    private void Start()
    {
        coins = PlayerPrefs.GetInt("Coins");
        coinsText.text = coins.ToString();
        DisplayBattery();
        DisplayMagnet();
    }

    void DisplayBattery()
    {
        string info = "Lvl " + powerupManager.Battery.level + "\n";
        if(powerupManager.Battery.nextUpgrade == null)
        {
            info += "Max level";
            batteryButton.interactable = false;
        }
        else
        {
            info += powerupManager.Battery.upgradeCost + " coins to upgrade";
        }

        batteryInfoText.text = info;
    }
    public void UpgradeBattery()
    {
        if(coins >= powerupManager.Battery.upgradeCost)
        {
            coins -= powerupManager.Battery.upgradeCost;
            PlayerPrefs.SetInt("Coins", coins);
            coinsText.text = coins.ToString();

            powerupManager.Battery = powerupManager.Battery.nextUpgrade;

            DisplayBattery();
        }
        else
        {
            Debug.Log("Not enough money");
        }
    }

    void DisplayMagnet()
    {
        string info = "Lvl " + powerupManager.Magnet.level + "\n";
        if (powerupManager.Magnet.nextUpgrade == null)
        {
            info += "Max level";
            magnetButton.interactable = false;
        }
        else
        {
            info += powerupManager.Magnet.upgradeCost + " coins to upgrade";
        }

        magnetInfoText.text = info;
    }

    public void UpgradeMagnet()
    {
        if (coins >= powerupManager.Magnet.upgradeCost)
        {
            coins -= powerupManager.Magnet.upgradeCost;
            PlayerPrefs.SetInt("Coins", coins);
            coinsText.text = coins.ToString();

            powerupManager.Magnet = powerupManager.Magnet.nextUpgrade;

            DisplayMagnet();
        }
        else
        {
            Debug.Log("Not enough money");
        }
    }
}
