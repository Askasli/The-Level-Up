using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

/// <summary>
/// Handles the camera behavior, following the player using DI
/// </summary>
public class CameraHandler : MonoBehaviour
{
    /// <summary>
    /// The speed at which the camera follows the player.
    /// </summary>
    [SerializeField] private float speed = 2f;

    private Camera _camera;
    private ICameraFollow _cameraFollow;

    /// <summary>
    /// Injects the ICameraFollow dependency during construction.
    /// </summary>
    [Inject]
    private void Construct(ICameraFollow cameraFollow)
    {
        _cameraFollow = cameraFollow;
    }

    /// <summary>
    /// Initializes the Camera component at the start of the scene.
    /// </summary>
    private void Start()
    {
        _camera = GetComponent<Camera>();
    }

    /// <summary>
    /// Updates the camera position
    /// </summary>
    private void LateUpdate()
    {
        _cameraFollow.FollowPlayer(_camera, speed);
    }
}
