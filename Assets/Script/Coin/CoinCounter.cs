using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Implements the ICoinCounter interface for tracking and managing in-game coins.
/// </summary>
public class CoinCounter : ICoinCounter
{
    private int currentCoins = 0;
    
    /// <summary>
    /// Dictionary storing the costs of leveling up different attributes.
    /// </summary>
    private Dictionary<AttributeType, int> attributeLevelCosts = new Dictionary<AttributeType, int>
    {
        { AttributeType.Vitality, 10 },
        { AttributeType.Strength, 10 },
        { AttributeType.Dexterity, 10 }
    };

    /// <summary>
    /// Event triggered when the number of coins changes.
    /// </summary>
    public event Action<int, bool> OnCoinsChanged;

    /// <summary>
    /// Adds the specified amount of coins to the current total.
    /// </summary>
    public void CollectCoins(int amount)
    {
        currentCoins += amount;
        OnCoinsChanged?.Invoke(amount, true);
        Debug.Log(currentCoins + " current Coins");
    }

    /// <summary>
    /// Attempts to spend the specified amount of coins.
    /// </summary>
    public bool SpendCoins(int amount)
    {
        if (currentCoins >= amount)
        {
            currentCoins -= amount;
            OnCoinsChanged?.Invoke(amount, false);
            return true;
        }

        return false;
    }

    /// <summary>
    /// Gets the current number of coins.
    /// </summary>
    public int GetCurrentCoins()
    {
        return currentCoins;
    }

    /// <summary>
    /// Gets the cost of leveling up a specific attribute.
    /// </summary>
    public int GetLevelUpCost(AttributeType attributeType)
    {
        return attributeLevelCosts[attributeType];
    }

    /// <summary>
    /// Increases the cost of leveling up the specified attribute.
    /// </summary>
    public void LevelUp(AttributeType attributeType)
    {
        attributeLevelCosts[attributeType] += 2;
        Debug.Log(attributeLevelCosts[attributeType] + " levelUpCost " + attributeType);
    }
}

