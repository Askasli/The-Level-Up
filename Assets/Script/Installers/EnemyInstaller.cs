using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EnemyInstaller : MonoInstaller
{
    /// <summary>
    /// Installer for setting up bindings related to enemy movement.
    /// </summary>
    public override void InstallBindings()
    {
        Container.Bind<IEnemyMove>().To<EnemyMove>().AsSingle();
    }
}
