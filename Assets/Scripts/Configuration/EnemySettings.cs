using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "Enemy", menuName = "Presets/Enemy")]
public class EnemySettings : ScriptableObjectInstaller
{
    [SerializeField] private Enemy.Parameters parameters;

    public override void InstallBindings()
    {
        Container.BindInstance(parameters);
        Container.BindInstance(parameters.MovementParameters);
        Container.BindInstance(parameters.HealthParameters);
        Container.BindInstance(parameters.DamagerParameters);
        Container.BindInstance(parameters.LootParameters);
    }
}
