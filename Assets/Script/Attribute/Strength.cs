using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Strength attribute
/// </summary>
public class Strength : IAttribute
{
    /// <summary>
    /// The base value of Strength.
    /// </summary>
    private const float BaseStrengthValue = 10f;
    
    /// <summary>
    /// Gets or sets the level of the Strength attribute.
    /// </summary>
    public int Level { get; set; }
   
    /// <summary>
    /// Event triggered when the Strength attribute changes, providing the new value.
    /// </summary>
    public event Action<float> AttributeChanged;
    
    
    /// <summary>
    /// Updates the parameters of the Strength attribute based on its level.
    /// </summary>
    public void UpdateParameters()
    {
        float strengthIncrease = 2f;
        float newStrength = 10f + (Level * strengthIncrease);

        Debug.Log(newStrength + " newStrength");
        AttributeChanged?.Invoke(newStrength);
    }
    
 
}
