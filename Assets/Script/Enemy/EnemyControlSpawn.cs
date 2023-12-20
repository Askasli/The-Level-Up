using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

/// <summary>
/// Controls the spawning and management of enemy units.
/// </summary>

public class EnemyControlSpawn : IEnemyControlSpawn
{
    private Transform _targetPosition;
    private PlayerHandler _player;
    private List<EnemyHandler.Factory> _enemyFactories;
    private List<EnemyHandler> _existingEnemies = new List<EnemyHandler>();

    private int spawnedEnemyCount;
    private int maxEnemyCount = 10;

    private float lastSpawnTime;
    private float minDelayBetweenSpawns = 2f;

    private const float MinSpawnDistance = 15f;
    private const float MinHeightOffset = -10f;
    private const float MaxHeightOffset = 10f;

    [Inject]
    public EnemyControlSpawn(List<EnemyHandler.Factory> enemyFactories, PlayerHandler player)
    {
        _enemyFactories = enemyFactories;
        _player = player;
    }


    /// <summary>
    /// Spawns enemies if the maximum count has not been reached and enough time has passed since the last spawn.
    /// </summary>
    public void Spawner()
    {
        if (spawnedEnemyCount < maxEnemyCount && Time.realtimeSinceStartup - lastSpawnTime > minDelayBetweenSpawns)
        {
            SpawnRandomEnemy();
            spawnedEnemyCount++;
        }
    }

    /// <summary>
    /// Spawns a random enemy using a randomly chosen factory.
    /// </summary>
    private void SpawnRandomEnemy()
    {
        if (spawnedEnemyCount >= maxEnemyCount)
        {
            return;
        }

        int randomIndex = Random.Range(0, _enemyFactories.Count);
        var chosenFactory = _enemyFactories[randomIndex];

        if (chosenFactory != null)
        {
            var enemyManager = chosenFactory.Create();
            enemyManager.OnEnemyDeath += HandleEnemyDeath;
            enemyManager.transform.position = ChooseRandomStartPosition(_existingEnemies);

            _existingEnemies.Add(enemyManager);
            spawnedEnemyCount++;
            lastSpawnTime = Time.realtimeSinceStartup;
        }
    }

    /// <summary>
    /// Handles the event when an enemy dies, triggering the spawning of a new enemy.
    /// </summary>
    void HandleEnemyDeath(EnemyHandler enemyManager)
    {
        enemyManager.OnEnemyDeath -= HandleEnemyDeath;
        spawnedEnemyCount--;

        _existingEnemies.Remove(enemyManager);
        SpawnRandomEnemy();
    }

    /// <summary>
    /// Chooses a random start position for a new enemy, avoiding collisions with existing enemies.
    /// </summary>
    Vector3 ChooseRandomStartPosition(List<EnemyHandler> existingEnemies)
    {
        Vector2 playerPosition = _player.transform.position;

        float angle = Random.Range(0f, 360f);
        float distance = Random.Range(10f, 25f);
        float heightOffset = Random.Range(MinHeightOffset, MaxHeightOffset);

        Vector2 spawnOffset = Quaternion.Euler(0f, 0f, angle) * Vector2.right * distance;
        Vector2 spawnPosition = playerPosition + new Vector2(spawnOffset.x, heightOffset) + Vector2.up; // Adjusted the height calculation

        foreach (var enemy in existingEnemies)
        {
            if (Vector2.Distance(spawnPosition, enemy.transform.position) < MinSpawnDistance)
            {
                return ChooseRandomStartPosition(existingEnemies);
            }
        }

        return spawnPosition;
    }
}
    

