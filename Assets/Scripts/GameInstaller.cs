using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private MovementAlongPath enemyPrefab;
    [SerializeField] private Castle castle;     

    public override void InstallBindings()
    {
        Container.BindFactory<Enemy, Enemy.Factory>()
            .FromComponentInNewPrefab(enemyPrefab)
            .UnderTransformGroup("Enemies");
        Container.BindInstance(castle);
        Container.BindInstance<ILiving>(castle);
    }
}
