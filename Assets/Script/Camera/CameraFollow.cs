using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

/// <summary>
/// Implementation of the ICameraFollow interface for following the player with a camera.
/// </summary>

public class CameraFollow : ICameraFollow
{
    private Transform playerTransform;

    /// <summary>
    /// Injects the player dependency during construction.
    /// </summary>
    [Inject]
    private void Construct(PlayerHandler player)
    {
        playerTransform = player.transform;
    }

    /// <summary>
    /// Follows the player with the given camera using a specified speed.
    /// </summary>
    public void FollowPlayer(Camera camera, float camSpeed)
    {
        //Vector3.Lerp to smoothly interpolate the camera position towards the player's position.
        camera.transform.position = Vector3.Lerp(camera.transform.position, playerTransform.transform.position + new Vector3(0, 0, -10f), Time.deltaTime * camSpeed);
    }
}
