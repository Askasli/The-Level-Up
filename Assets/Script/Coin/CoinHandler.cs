using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

/// <summary>
/// Handles the spawning of coins using the CoinFactory.
/// </summary>
public class CoinHandler : ICoinHandler
{
    private Coin.Factory _coinFactory;

    /// <summary>
    /// Injects the Coin.Factory DI
    /// </summary>
    [Inject]
    public CoinHandler(Coin.Factory coinFactory)
    {
        _coinFactory = coinFactory;
    }

    /// <summary>
    /// Spawning of a coin at the position of an enemy.
    /// </summary>
    public void HandleCoinSpawn(EnemyHandler enemyHandler)
    {
        var coin = _coinFactory.Create();
        coin.transform.position = enemyHandler.transform.position;
        coin.gameObject.SetActive(true);
    }
}
