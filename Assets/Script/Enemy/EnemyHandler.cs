using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;


/// <summary>
/// Handles the behavior of enemy units.
/// </summary>
public class EnemyHandler : MonoBehaviour, IPoolable<IMemoryPool>
{
    [SerializeField] private float speed;
    public event Action<EnemyHandler> OnEnemyDeath;
    private IMemoryPool _pool;
    private IEnemyMove _enemyMove;
    private ICoinHandler _coinHandler;
    

    /// <summary>
    /// DI, The movement and rotation controller for the enemy and coin handler for managing coins when the enemy is destroyed
    /// </summary>
    [Inject]
    private void Construct(IEnemyMove enemyMove, ICoinHandler coinHandler)
    {
        _enemyMove = enemyMove;
        _coinHandler = coinHandler;
    }
    
    
    /// <summary>
    /// Updates the enemys movement and rotation
    /// </summary>
    private void Update()
    {
        _enemyMove.MoveToward(transform, speed);
        _enemyMove.RotateToward(transform);
    }

    /// <summary>
    /// Enemy is despawned from the object pool.
    /// </summary>
    public void OnDespawned()
    {
        _pool = null;
    }

    /// <summary>
    /// Enemy is spawned from the object pool.
    /// </summary>
    public void OnSpawned(IMemoryPool pool)
    {
        _pool = pool;
    }

    
    /// <summary>
    /// Returns the enemy to the object pool
    /// </summary>
    public void ReturnToPool()
    {
        OnEnemyDeath?.Invoke(this);
        _pool?.Despawn(this);
    }

    /// <summary>
    /// Called when the enemy collider triggers with another collider.
    /// </summary>
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            ReturnToPool();
        }

        if (collider.CompareTag("Slash"))
        {
            ReturnToPool();
            _coinHandler.HandleCoinSpawn(this);
        }
    }

    
    /// <summary>
    /// Factory 
    /// </summary>
    public class Factory : PlaceholderFactory<EnemyHandler>
    {
    }


}
