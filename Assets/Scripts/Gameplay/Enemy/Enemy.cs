using System;
using TowerDefence.Gameplay.Damage;
using TowerDefence.Gameplay.HealthSystem;
using TowerDefence.Gameplay.LootSystem;
using TowerDefence.Gameplay.Movement;
using UnityEngine;
using Zenject;

namespace TowerDefence.Gameplay.EnemySystem
{
    public class Enemy : MonoBehaviour, ILiving
    {
        public Health Health { get; private set; }

        private Targeter<Health> targeter;
        private MovementAlongPath movement;
        private Damager damager;
        private Loot loot;

        [Inject]
        public void Construct(Health health, Targeter<Health> targeter, MovementAlongPath movement, Damager damager, Loot loot)
        {
            this.targeter = targeter;
            this.Health = health;
            this.movement = movement;
            this.damager = damager;
            this.loot = loot;
        }

        private void Start()
        {
            targeter.OnTargetAcquired += AttackTarget;
            Health.OnHealthZero += OnDeath;
        }

        public void SetParameters(Parameters enemyParameters)
        {
            damager.SetParameters(enemyParameters.DamagerParameters);
            Health.SetParameters(enemyParameters.HealthParameters);
            loot.SetParameters(enemyParameters.LootParameters);
        }

        private void AttackTarget(Health target)
        {
            damager.DoDamage(target);
            Destroy(gameObject);
        }

        private void OnDeath()
        {
            Health.OnHealthZero -= OnDeath;
            loot.ApplyLoot();
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
        public class Parameters : ICloneable
        {
            [SerializeField] private TargetMovement.Parameters movementParameters;
            public TargetMovement.Parameters MovementParameters
            {
                get { return movementParameters; }
                set { movementParameters = value; }
            }
            [SerializeField] private Health.Parameters healthParameters;
            public Health.Parameters HealthParameters
            {
                get { return healthParameters; }
                set { healthParameters = value; }
            }
            [SerializeField] private Damager.Parameters damagerParameters;
            public Damager.Parameters DamagerParameters
            {
                get { return damagerParameters; }
                set { damagerParameters = value; }
            }
            [SerializeField] private Loot.Parameters lootParameters;
            public Loot.Parameters LootParameters
            {
                get { return lootParameters; }
                set { lootParameters = value; }
            }

            public Parameters(TargetMovement.Parameters movementParameters,
                              Health.Parameters healthParameters,
                              Damager.Parameters damagerParameters,
                              Loot.Parameters lootParameters)
            {
                this.movementParameters = movementParameters;
                this.healthParameters = healthParameters;
                this.damagerParameters = damagerParameters;
                this.lootParameters = lootParameters;
            }

            public object Clone()
            {
                return new Parameters(movementParameters, healthParameters, damagerParameters, lootParameters);
            }
        }
    } 
}
