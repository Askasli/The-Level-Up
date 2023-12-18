using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Interface for handling slash rotation.
/// </summary>
public interface IRotationSlashHandler
{
    void SlashRotation(Transform slashTransform, Transform playerTransform);

}
