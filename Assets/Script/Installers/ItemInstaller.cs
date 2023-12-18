using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

/// <summary>
/// Installer for setting up bindings related to items, coins, etc
/// </summary>
public class ItemInstaller : MonoInstaller
{
    [SerializeField] private GameObject coinFX;
    
    
    public override void InstallBindings()
    {
        Container.BindFactory<Coin, Coin.Factory>().FromPoolableMemoryPool<Coin, CoinPool>(poolBinder => poolBinder.WithInitialSize(10).FromComponentInNewPrefab(coinFX).UnderTransformGroup("Coins"));
        
        Container.Bind<ICoinHandler>().To<CoinHandler>().AsSingle(); 
        Container.Bind<ICoinCounter>().To<CoinCounter>().AsSingle();
        Container.Bind<CoinManager>().AsSingle();

    }
    
    /// <summary>
    /// Memory pool for managing the spawning and despawning of coin instances.
    /// </summary>
    class CoinPool : MonoPoolableMemoryPool<IMemoryPool, Coin>
    {
        
    }
    
}
