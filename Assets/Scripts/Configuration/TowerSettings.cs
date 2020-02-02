using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName ="Tower", menuName ="Presets/Tower")]
public class TowerSettings : ScriptableObjectInstaller
{
    [SerializeField] private Tower.Parameters towerSettings;
    public override void InstallBindings()
    {
        Container.BindInstance(towerSettings);
        Container.BindInstance(towerSettings.TargeterParameters);
        Container.BindInstance(towerSettings.DamagerParameters);
    }
}
