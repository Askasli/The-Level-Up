using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Interface for providing movement direction.
/// </summary>
public interface IMoveDirection
{
    /// <summary>
    /// Gets the movement direction.
    /// </summary>
    Vector3 moveDirection();
}
