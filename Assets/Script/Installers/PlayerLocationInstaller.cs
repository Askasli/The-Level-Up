using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

/// <summary>
/// Installer for setting up bindings related to player position
/// </summary>
public class PlayerLocationInstaller : MonoInstaller
{
    [SerializeField] private Transform playerPrefab;
    [SerializeField] private Transform startPoint;
    
    public override void InstallBindings()
    {
        Container.Bind<PlayerHandler>().FromComponentInNewPrefab(playerPrefab).WithGameObjectName("Player").AsSingle();
    }
    
    /// <summary>
    /// Sets the initial position for the player
    /// </summary>
    private void Awake()
    {
        PlayerHandler player = Container.Resolve<PlayerHandler>();
        player.transform.position = startPoint.position;
    }
    
}
