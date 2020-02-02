using TowerDefence.Gameplay;
using UnityEngine;
using Zenject;

namespace TowerDefence.Configuration
{
    [CreateAssetMenu(fileName = "WavesSettings", menuName = "Presets/Wave")]
    public class WavesSettings : ScriptableObjectInstaller
    {
        [SerializeField] private WavesController.Parameters levelParameters;

        public override void InstallBindings()
        {
            Container.BindInstance(levelParameters);
        }
    } 
}

