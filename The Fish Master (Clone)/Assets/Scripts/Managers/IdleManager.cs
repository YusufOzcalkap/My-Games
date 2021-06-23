using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class IdleManager : MonoBehaviour
{
    [HideInInspector]
    public int lenght;

    [HideInInspector]
    public int strength;

    [HideInInspector]
    public int offlineEarnings;

    [HideInInspector]
    public int lenghtCost;

    [HideInInspector]
    public int strengthCost;

    [HideInInspector]
    public int offlineEarningsCost;

    [HideInInspector]
    public int wallet;

    [HideInInspector]
    public int totalGain;

    private int[] costs = new int[]
    {
        120,
        151,
        197,
        250,
        324,
        414,
        537,
        687,
        892,
        1145,
        1484,
        1911,
        2479,
        3196,
        4148,
        5359,
        6954,
        9000,
        11687
    };

    public static IdleManager instance;

    void Awake()
    {
        if (IdleManager.instance)
        {
            UnityEngine.Object.Destroy(gameObject);
        }
        else
        {
            IdleManager.instance = this;
        }

        lenght = -PlayerPrefs.GetInt("Length", 30);
        strength = PlayerPrefs.GetInt("Strength", 3);
        offlineEarnings = PlayerPrefs.GetInt("Offline", 3);
        lenghtCost = costs[-lenght / 10 - 3];
        strengthCost = costs[strength - 3];
        offlineEarningsCost = costs[offlineEarnings - 3];
        wallet = PlayerPrefs.GetInt("Wallet", 0);

    }

    private void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            DateTime now = DateTime.Now;
            PlayerPrefs.SetString("Date", now.ToString());
            MonoBehaviour.print(now.ToString());
        }
        else
        {
            string @string = PlayerPrefs.GetString("Date", string.Empty);
            if (@string != string.Empty)
            {
                DateTime d = DateTime.Parse(@string);
                totalGain = (int)((DateTime.Now - d).TotalMinutes * offlineEarnings+ 1.0);
                ScreenManager.instance.ChangeScreen(Screens.RETURN);
            }
        }
    }

    private void OnApplicationQuit()
    {
        OnApplicationPause(true);  
    }

   
    public void BuyLength()
    {
        lenght -= 10;
        wallet -= lenghtCost;
        lenghtCost = costs[-lenght / 10 - 3];
        PlayerPrefs.SetInt("length", -lenght);
        PlayerPrefs.SetInt("Wallet", wallet);
        ScreenManager.instance.ChangeScreen(Screens.MAIN);

    }

    public void BuyStrength()
    {
        strength++;
        wallet -= strengthCost;
        strengthCost = costs[strength - 3];
        PlayerPrefs.SetInt("Strength", -lenght);
        PlayerPrefs.SetInt("Wallet", wallet);
        ScreenManager.instance.ChangeScreen(Screens.MAIN);

    }

    public void BuyOfflineEarnings()
    {
        offlineEarnings++;
        wallet -= offlineEarningsCost;
        strengthCost = costs[offlineEarnings - 3];
        PlayerPrefs.SetInt("Offline", -lenght);
        PlayerPrefs.SetInt("Wallet", wallet);
        ScreenManager.instance.ChangeScreen(Screens.MAIN);

    }

    public void CollectMoney()
    {
        wallet += totalGain;
        PlayerPrefs.SetInt("Wallet", wallet);
        ScreenManager.instance.ChangeScreen(Screens.MAIN);

    }

    public void CollectDoubleMoney()
    {
        wallet += totalGain * 2;
        PlayerPrefs.SetInt("Wallet", wallet);
        ScreenManager.instance.ChangeScreen(Screens.MAIN);

    }
}
