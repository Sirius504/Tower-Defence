using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "Enemy", menuName = "Presets/Enemy")]
public class EnemySettings : ScriptableObjectInstaller
{
    [SerializeField] private Enemy.Settings settings;

    public override void InstallBindings()
    {
        Container.BindInstance(settings);
        Container.BindInstance(settings.movementSettings);
        Container.BindInstance(settings.lifeSettings);
        Container.BindInstance(settings.damagerSettings);
    }
}
