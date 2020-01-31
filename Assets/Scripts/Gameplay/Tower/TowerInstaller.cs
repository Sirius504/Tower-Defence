using UnityEngine;
using Zenject;

public class TowerInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<Damager>().AsSingle();
    }
}