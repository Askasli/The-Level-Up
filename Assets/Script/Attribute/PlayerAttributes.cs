using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Types of attributes available for the player.
/// </summary>
public enum AttributeType
{
    Vitality,
    Strength,
    Dexterity
}


/// <summary>
/// Manages the player attributes, including level-up.
/// </summary>
public class PlayerAttributes
{
    private const int InitialAttributeValue = 1;
    private const int MinAttributeValue = 1;
    private const int MaxAttributeValue = 99;

    private List<IAttribute> attributes;

    /// <summary>
    /// А new instance of the PlayerAttributes class.
    /// </summary>
    public PlayerAttributes()
    {
        InitializeAttributes();
    }

    private void InitializeAttributes()
    {
        attributes = new List<IAttribute>
        {
            new Vitality { Level = InitialAttributeValue },
            new Strength { Level = InitialAttributeValue },
            new Dexterity { Level = InitialAttributeValue }
            // we can add others attributes if its needed
        };
    }

    
    /// <summary>
    /// Increases the level of a specific attribute for the player.
    /// </summary>
    public void LevelUpAttribute(AttributeType attributeType, int levelsToIncrease)
    {
        int attributeIndex = (int)attributeType;

        if (attributeIndex >= 0 && attributeIndex < attributes.Count)
        {
            attributes[attributeIndex].Level += levelsToIncrease;

            // Limit values within the range [MinAttributeValue, MaxAttributeValue]
            attributes[attributeIndex].Level = Mathf.Clamp(attributes[attributeIndex].Level, MinAttributeValue, MaxAttributeValue);
            attributes[attributeIndex].UpdateParameters(); // Update parameters after level increase
        }
    }

    /// Gets the current level of a specific attribute.
    public int GetCurrentAttributeValue(AttributeType attributeType)
    {
        int attributeIndex = (int)attributeType;

        if (attributeIndex >= 0 && attributeIndex < attributes.Count)
        {
            return attributes[attributeIndex].Level;
        }

        return 0;
    }
    
    /// <summary>
    /// Gets the player overall level by summing all attribute levels.
    /// </summary>
    public int GetCharacterLevel()
    {
        int totalLevel = 0;

        foreach (var attribute in attributes)
        {
            totalLevel += attribute.Level;
        }

        return totalLevel;
    }
    
    
}

