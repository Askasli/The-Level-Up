using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Vitality attribute, implementing the IAttribute interface.
/// </summary>
public class Vitality : IAttribute
{
    /// <summary>
    /// The base value of Vitality.
    /// </summary>
    private const float BaseHealthValue = 100f;
   
    /// <summary>
    /// Gets or sets the level of the Vitality attribute.
    /// </summary>
    public int Level { get; set; }
    
    /// <summary>
    /// Event triggered when the Vitality attribute changes, providing the new value.
    /// </summary>
    public event Action<float> AttributeChanged;
    
    /// <summary>
    /// Updates the parameters of the Vitality attribute based on its level.
    /// </summary>
    public void UpdateParameters()
    {
        float healthIncreasePercentage = 1f;
        float newHealthPercentage = 100f + (Level * healthIncreasePercentage);
        AttributeChanged?.Invoke(newHealthPercentage);
        Debug.Log(newHealthPercentage + "newHealth");
    }
  
}