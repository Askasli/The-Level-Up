using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Interface for camera following 
/// </summary>
public interface ICameraFollow
{
    void FollowPlayer(Camera camera, float camSpeed);
}
