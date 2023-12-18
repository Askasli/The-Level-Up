using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

/// <summary>
/// Controls the movement and rotation of enemy.
/// </summary>
public class EnemyMove : IEnemyMove
{
    private PlayerHandler _playerHandler;
    private float rotationSpeed = 30f;

    /// <summary>
    /// Injects the player handler instance to track the players position
    /// </summary>
    [Inject]
    public EnemyMove(PlayerHandler playerHandler)
    {
        _playerHandler = playerHandler;
    }

    /// <summary>
    /// Rotates the enemy towards the players position.
    /// </summary>
    public void RotateToward(Transform currentTransform)
    {
        Vector3 playerDirection = (_playerHandler.transform.position - currentTransform.position).normalized;
        float targetAngle = Mathf.Atan2(playerDirection.y, playerDirection.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.Euler(0f, 0f, targetAngle);
        currentTransform.rotation = Quaternion.RotateTowards(currentTransform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    /// <summary>
    /// Moves the enemy towards the players position
    /// </summary>
    public void MoveToward(Transform currentTransform, float speed)
    {
        Vector3 playerDirection = (_playerHandler.transform.position - currentTransform.position).normalized;
        Vector3 moveDirection = new Vector3(playerDirection.x, playerDirection.y, 0f).normalized;
        currentTransform.position += moveDirection * speed * Time.deltaTime;
    }

   
}
