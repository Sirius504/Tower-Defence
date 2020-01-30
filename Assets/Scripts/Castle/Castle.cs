using Signals;
using System;
using UnityEngine;
using Zenject;

public class Castle : MonoBehaviour, ILiving
{
    public Life Life { get; private set; }
    private SignalBus signalBus;

    [Inject]
    public void Construct(Life life, SignalBus signalBus)
    {
        this.Life = life;
        this.signalBus = signalBus;
        life.OnLifeZero += SendGameOver;
    }

    private void SendGameOver()
    {
        signalBus.Fire(new GameOverSignal());
    }

    public void TakeDamage(float amount)
    {
        Life.Change(-amount);
    }

    [Serializable]
    public class Settings
    {
        public Life.Settings lifeSettings;
    }
}
