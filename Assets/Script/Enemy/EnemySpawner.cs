using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

/// <summary>
/// Spawns enemies
/// </summary>
public class EnemySpawner : MonoBehaviour
{
    private IEnemyControlSpawn _enemyControlSpawn;
    
    /// <summary>
    /// Injects for EnemyControlSpawn
    /// </summary>
    [Inject]
    private void Construct(IEnemyControlSpawn enemyControlSpawn)
    {
        _enemyControlSpawn = enemyControlSpawn;
    }

    /// <summary>
    /// Updates the enemy spawner
    /// </summary>
    private void Update()
    {
        _enemyControlSpawn.Spawner();
    }
}
