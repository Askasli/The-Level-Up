using System;
using UnityEngine;

/// <summary>
/// Implementation of IRotationEnable interface for enabling and controlling rotation behavior.
/// </summary>
public class RotationEnable : IRotationEnable
{
    /// <summary>
    /// Event triggered when the rotation state changes.
    /// </summary>
    public event Action<bool> OnRotationChange;
    
    
    private bool canRotate;
    
    /// <summary>
    /// Checks if rotation is allowed.
    /// </summary>
    public bool CanRotate()
    {
        return canRotate;
    }
    
    public void SetRotationValue(bool value)
    {
        if (canRotate != value)
        {
            Debug.Log(value + "RotateEnableStatus");
            canRotate = value;
            OnRotationChange?.Invoke(canRotate);
        }
    }
}
