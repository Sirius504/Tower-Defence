using System;
using UnityEngine;
using Zenject;

public class Enemy : MonoBehaviour
{
    private EnemyTargeter targeter;
    private Life life;
    private Settings settings;

    [Inject]
    public void Construct(Settings settings, Life life, EnemyTargeter targeter)
    {
        this.targeter = targeter;
        this.life = life;
        this.settings = settings;
        targeter.OnTargetAcquired += DamageCastle;
        life.OnLifeZero += OnDeath;
    }

    private void DamageCastle(Castle castle)
    {
        castle.TakeDamage(settings.damage);
        Destroy(gameObject);
    }

    private void OnDeath()
    {
        life.OnLifeZero -= OnDeath;
        Destroy(gameObject);
    }

    public void TakeDamage(float amount)
    {
        life.Change(-amount);
    }

    public class Factory : PlaceholderFactory<Enemy>
    {
    }

    [Serializable]
    public class Settings
    {
        public TargetMovement.Settings movementSettings;
        public Life.Settings lifeSettings;
        public float damage;
        public float loot;
    }
}
