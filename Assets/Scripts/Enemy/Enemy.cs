using System;
using UnityEngine;
using Zenject;

public class Enemy : MonoBehaviour, ILiving
{
    public Life Life { get; private set; }

    private Targeter<ILiving> targeter;
    private MovementAlongPath movement;
    private Damager damager;

    [Inject]
    public void Construct(Life life, Targeter<ILiving> targeter, MovementAlongPath movement, Damager damager)
    {
        this.targeter = targeter;
        this.Life = life;
        this.movement = movement;
        this.damager = damager;
        targeter.OnTargetAcquired += AttackTarget;
        life.OnLifeZero += OnDeath;
    }

    private void AttackTarget(ILiving target)
    {
        damager.DoDamage(target);
        Destroy(gameObject);
    }

    private void OnDeath()
    {
        Life.OnLifeZero -= OnDeath;
        Destroy(gameObject);
    }

    public Vector3 GetSpeed()
    {
        return movement.GetSpeed();
    }

    public class Factory : PlaceholderFactory<Enemy>
    {
    }

    [Serializable]
    public class Settings
    {
        public TargetMovement.Settings movementSettings;
        public Life.Settings lifeSettings;
        public Damager.Settings damagerSettings;
        public float loot;
    }
}
