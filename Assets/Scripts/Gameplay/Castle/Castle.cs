using Signals;
using System;
using UnityEngine;
using Zenject;

public class Castle : MonoBehaviour, ILiving
{
    public Health Health { get; private set; }
    private SignalBus signalBus;

    [Inject]
    public void Construct(Health health, SignalBus signalBus)
    {
        this.Health = health;
        this.signalBus = signalBus;
    }

    public void Start()
    {
        Health.OnHealthZero += SendGameOver;
    }

    private void SendGameOver()
    {
        signalBus.Fire(new GameOverSignal());
    }

    public void TakeDamage(int amount)
    {
        Health.Change(-amount);
    }

    [Serializable]
    public class Settings
    {
        public Health.Parameters healthSettings;
    }
}
