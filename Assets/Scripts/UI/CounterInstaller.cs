using UnityEngine;
using Zenject;

public class CounterInstaller : MonoInstaller
{
    [SerializeField] private string label;

    public override void InstallBindings()
    {
        Container.BindInstance(label);
    }
}