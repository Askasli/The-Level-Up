using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Interface for controlling the movement and rotation of enemy units.
/// </summary>
public interface IEnemyMove
{
   /// <summary>
   /// Rotates the enemy towards the plater
   /// </summary>
   void RotateToward(Transform currentTransform);
   
   /// <summary>
   /// Moves the enemy towards the player, with own speed
   /// </summary>
   void MoveToward(Transform currentTransform, float speed);

}
