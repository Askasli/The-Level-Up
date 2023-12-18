using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

/// <summary>
/// Installer for setting up bindings related to camera following.
/// </summary>
public class CameraInstaller : MonoInstaller
{
    /// <summary>
    /// Installs Zenject bindings for camera following.
    /// </summary>
    public override void InstallBindings()
    {
        Container.Bind<ICameraFollow>().To<CameraFollow>().AsSingle();
    }
}
