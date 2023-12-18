using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

/// <summary>
/// Coin logic, implementing IPoolable for object pooling.
/// </summary>
public class Coin : MonoBehaviour,  IPoolable<IMemoryPool>
{
    private IMemoryPool _pool;
    private ICoinCounter _coinCounter;
    
    
    /// <summary>
    /// Injects the ICoinCounter dependency during construction.
    /// </summary>
    [Inject]
    private void Construct(ICoinCounter coinCounter)
    {
        _coinCounter = coinCounter;
    }
    
    /// <summary>
    /// Callback when the object is despawned from the pool.
    /// </summary>
    public void OnDespawned()
    {
        _pool = null;
    }

    /// <summary>
    /// Callback when the object is spawned from the pool.
    /// </summary>
    public void OnSpawned(IMemoryPool pool)
    {
        _pool = pool;
        StartCoroutine(ReturnToPoolDelay(10f));
        
    }
    
    /// <summary>
    /// Returns the coin to the object pool.
    /// </summary>
    public void ReturnToPool()
    {
        _pool?.Despawn(this);
    }
    
    /// <summary>
    /// Triggered when the coin enters a collider.
    /// </summary>
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            _coinCounter.CollectCoins(10);
            ReturnToPool();
        }

    }

    /// <summary>
    /// Coroutine to delay the return of the coin to the pool.
    /// </summary>
    private IEnumerator ReturnToPoolDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        ReturnToPool();
    }
    
    /// <summary>
    /// Placeholder factory for creating instances of the Coin class.
    /// </summary>
    public class Factory : PlaceholderFactory<Coin>
    {
    }
}
