using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

/// <summary>
/// Installer for setting up bindings related to spawning and enemy pooling.
/// </summary>
public class EnemyPool : MonoInstaller
{
    [SerializeField] private Transform _enemyPrefab;
    
    /// <summary>
    /// Installs bindings for enemy spawning and pooling.
    /// </summary>
    public override void InstallBindings()
    {
        Container.Bind<IEnemyControlSpawn>().To<EnemyControlSpawn>().AsSingle();
        
        Container.BindFactory<EnemyHandler, EnemyHandler.Factory>().FromPoolableMemoryPool<EnemyHandler, EnemySpawnPool>(
            poolBinder => poolBinder.WithInitialSize(10).FromComponentInNewPrefab(_enemyPrefab).UnderTransformGroup("Enemies"));
   
    }
    
    
    /// <summary>
    /// Memory pool for managing the spawning and despawning of enemy units.
    /// </summary>
    class EnemySpawnPool : MonoPoolableMemoryPool<IMemoryPool, EnemyHandler>
    {
        
    }
}
