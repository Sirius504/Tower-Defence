using System;
using UnityEngine;
using Zenject;

public class Enemy : MonoBehaviour
{
    private EnemyTargeter targeter;
    private Life life;
    private Settings settings;
    private MovementAlongPath movement;

    [Inject]
    public void Construct(Settings settings, Life life, EnemyTargeter targeter, MovementAlongPath movement)
    {
        this.targeter = targeter;
        this.life = life;
        this.settings = settings;
        this.movement = movement;
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

    public Vector3 GetSpeed()
    {
        return movement.GetSpeed();
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
