using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

/// <summary>
/// Installer for setting up bindings related to player movement, rotation, and attributes.
/// </summary>
public class PlayerInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<IMoveSettings>().To<MoveSettings>().AsSingle();
        Container.Bind<IMoveDirection>().To<MoveDirection>().AsSingle(); 
        Container.Bind<IRotationSlashHandler>().To<RotationSlashHandler>().AsSingle();  
        Container.Bind<ISlashAttack>().To<SlashAttack>().AsSingle(); 
        Container.Bind<IRotationEnable>().To<RotationEnable>().AsSingle();  
        Container.Bind<Dexterity>().AsSingle();
        Container.Bind<Strength>().AsSingle();
        Container.Bind<Vitality>().AsSingle();
    }
}
