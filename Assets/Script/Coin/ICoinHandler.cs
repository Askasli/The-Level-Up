using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Interface for spawning of coins.
/// </summary>
public interface ICoinHandler
{
   /// <summary>
   /// Spawning of a coin at the position of an enemy.
   /// </summary>
   void HandleCoinSpawn(EnemyHandler enemyHandler);
}
