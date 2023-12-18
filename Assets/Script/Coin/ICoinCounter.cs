using System;

/// <summary>
/// Interface for tracking and managing in-game coins.
/// </summary>
public interface ICoinCounter
{
    /// <summary>
    /// Event triggered when the number of coins changes.
    /// </summary>
    event Action<int, bool> OnCoinsChanged;

    /// <summary>
    /// Collect and add coins
    /// </summary>
    void CollectCoins(int amount);
    
    /// <summary>
    /// Attempts to spend the specified amount of coins.
    /// </summary>
    bool SpendCoins(int amount);
    
    /// <summary>
    /// Gets the current number of coins.
    /// </summary>
    int GetCurrentCoins();
    
    /// <summary>
    /// Gets the current number of coins.
    /// </summary>
    int GetLevelUpCost(AttributeType attributeType);
    
    /// <summary>
    /// Increases the cost of leveling up the specified attribute.
    /// </summary>
    void LevelUp(AttributeType attributeType);
    
}
