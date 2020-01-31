using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class HealthInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<Health>().AsTransient();
    }
}
