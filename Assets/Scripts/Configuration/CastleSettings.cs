using TowerDefence.Gameplay.CastleSystem;
using UnityEngine;
using Zenject;

namespace TowerDefence.Configuration
{
    [CreateAssetMenu(fileName = "Castle", menuName = "Presets/Castle")]
    public class CastleSettings : ScriptableObjectInstaller
    {
        public Castle.Settings castleSettings;

        public override void InstallBindings()
        {
            Container.BindInstance(castleSettings.healthSettings);
        }
    }
}
