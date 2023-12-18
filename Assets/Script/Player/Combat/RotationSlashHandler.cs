using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

/// <summary>
/// Implementation of IRotationSlashHandler interface for handling slash rotation.
/// </summary>
public class RotationSlashHandler : IRotationSlashHandler
{ 
    private IRotationEnable _rotationEnable;
    private Vector3 mousePos;

    [Inject]
    public void Construct(IRotationEnable rotationEnable)
    {
        _rotationEnable = rotationEnable;
    }

    /// <summary>
    /// Rotates the slash transform based on the players transform and mouse position.
    /// </summary>
    public void SlashRotation(Transform slashTransform, Transform playerTransform)
    {
        mousePos = mousePosition(playerTransform);  // Rotate the weapon based on mouse position.
        mousePos.Normalize();

        float rot_z = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;  // Calculate the rotation angle in degrees based on the mouse position.
      
        if (_rotationEnable.CanRotate())    // Check if weapon rotation is enabled
        {
            slashTransform.rotation = Quaternion.Euler(0f, 0f, rot_z); 
        }
        
    }
    
    /// <summary>
    /// Gets the mouse position relative to the players transform.
    /// </summary>
    private Vector2 mousePosition(Transform _transform) //Getting mouse position
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition) - _transform.position;
    }
}
