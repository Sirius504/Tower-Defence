using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CastleInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<Life>().FromNew().AsSingle();
    }
}
