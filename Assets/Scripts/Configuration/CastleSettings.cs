using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName ="Castle", menuName = "Presets/Castle")]
public class CastleSettings : ScriptableObjectInstaller
{
    public Castle.Settings castleSettings;

    public override void InstallBindings()
    {
        Container.BindInstance(castleSettings.healthSettings);
    }
}
