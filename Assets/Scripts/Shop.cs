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
        string info = "Lvl " + powerupManager.battery.level + "\n";
        if(powerupManager.battery.nextUpgrade == null)
        {
            info += "Max level";
            batteryButton.interactable = false;
        }
        else
        {
            info += powerupManager.battery.upgradeCost + " coins to upgrade";
        }

        batteryInfoText.text = info;
    }
    public void UpgradeBattery()
    {
        if(coins >= powerupManager.battery.upgradeCost)
        {
            coins -= powerupManager.battery.upgradeCost;
            PlayerPrefs.SetInt("Coins", coins);
            coinsText.text = coins.ToString();

            powerupManager.battery = powerupManager.battery.nextUpgrade;

            DisplayBattery();
        }
        else
        {
            Debug.Log("Not enough money");
        }
    }

    void DisplayMagnet()
    {
        string info = "Lvl " + powerupManager.magnet.level + "\n";
        if (powerupManager.magnet.nextUpgrade == null)
        {
            info += "Max level";
            magnetButton.interactable = false;
        }
        else
        {
            info += powerupManager.magnet.upgradeCost + " coins to upgrade";
        }

        magnetInfoText.text = info;
    }

    public void UpgradeMagnet()
    {
        if (coins >= powerupManager.magnet.upgradeCost)
        {
            coins -= powerupManager.magnet.upgradeCost;
            PlayerPrefs.SetInt("Coins", coins);
            coinsText.text = coins.ToString();

            powerupManager.magnet = powerupManager.magnet.nextUpgrade;

            DisplayMagnet();
        }
        else
        {
            Debug.Log("Not enough money");
        }
    }
}
