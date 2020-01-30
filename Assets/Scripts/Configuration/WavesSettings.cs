using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "WavesSettings", menuName = "Presets/Wave")]
public class WavesSettings : ScriptableObjectInstaller
{
    [SerializeField] private WavesController.Settings levelSettings;

    public override void InstallBindings()
    {
        Container.BindInstance(levelSettings);
    }
}

