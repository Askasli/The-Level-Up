using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Dexterity attribute, implementing the IAttribute interface.
/// </summary>
public class Dexterity : IAttribute
{
    /// <summary>
    /// The base value of Dexterity.
    /// </summary>
    private const float BaseDexterityValue = 10f;
  
    /// <summary>
    /// Gets or sets the level of the Dexterity attribute.
    /// </summary>
    public int Level { get; set; }
    
    /// <summary>
    /// Event triggered when the attribute changes
    /// </summary>
    public event Action<float> AttributeChanged;
    
    
    /// <summary>
    /// Updates the parameters of the Dexterity attribute based on its level.
    /// </summary>
    public void UpdateParameters()
    {
        // The amount of Dexterity increase per level.
        float dexterityIncrease = 2f; 
        // Calculate the new Dexterity value based on the level.
        float newDexterity = BaseDexterityValue + (Level * dexterityIncrease);
        // Invoke the AttributeChanged event with the new Dexterity value.
        AttributeChanged?.Invoke(newDexterity);
        Debug.Log(newDexterity + " newDexterity");
    }
    
}
