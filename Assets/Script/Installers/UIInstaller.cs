using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

/// <summary>
/// Installer for setting up bindings related to UI components.
/// </summary>
public class UIInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<IPauseToggle>().To<PauseToggle>().AsSingle();
        Container.Bind<PlayerAttributes>().AsSingle();
    }
}
