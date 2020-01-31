using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private MovementAlongPath enemyPrefab;

    public override void InstallBindings()
    {
        Container.BindFactory<Enemy, Enemy.Factory>()
            .FromComponentInNewPrefab(enemyPrefab)
            .UnderTransformGroup("Enemies");
        Container.Bind<Gold>().AsSingle();
    }
}
