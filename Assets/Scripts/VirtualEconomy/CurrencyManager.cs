using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyManager : MonoBehaviour
{
    private int goldCoins;

    public CurrencyManager(int coins)
    {
        goldCoins = coins;
    }

    public int GetGoldCoins()
    {
        return goldCoins;
    }

    public void AddGoldCoins(int amount)
    {
        goldCoins += amount;
    }

    public bool SubtractGoldCoins(int amount)
    {
        if (goldCoins >= amount)
        {
            goldCoins -= amount;
            return true;
        }
        else
        {
            return false; // Insufficient funds
        }
    }


}
