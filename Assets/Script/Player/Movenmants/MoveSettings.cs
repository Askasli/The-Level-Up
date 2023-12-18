using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class MoveSettings : IMoveSettings
{
    private IMoveDirection _moveDirection;
    private float speed = 4f;
    
    [Inject]
    private void Construct(IMoveDirection moveDirection)
    {
        _moveDirection = moveDirection;
    }
    
    /// <summary>
    /// Moves the Rigidbody component based on the input direction
    /// </summary>
    public void MoveBody(Rigidbody2D rigidbody2D)
    {
        rigidbody2D.velocity = _moveDirection.moveDirection() * speed;
    }
}
