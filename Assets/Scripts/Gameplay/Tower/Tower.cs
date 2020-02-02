using System;
using UnityEngine;
using Zenject;

public class Tower : MonoBehaviour
{
    private float lastShotTime;
    private Parameters parameters;
    private ShellRenderer shellRenderer;
    private Targeter<Enemy> targeter;
    private Damager damager;


    [Inject]
    public void Construct(Parameters parameters, ShellRenderer shellRenderer, TowerTargeter targeter, Damager damager)
    {        
        this.parameters = parameters;
        this.shellRenderer = shellRenderer;
        this.targeter = targeter;
        this.damager = damager;
    }

    private void Start()
    {
        targeter.OnTargetAcquired += AttackEnemy;
        lastShotTime = Time.time;
    }

    private void AttackEnemy(Enemy target)
    {
        damager.DoDamage(target.Health);
        shellRenderer.DrawShotAt(target.transform.position, target.GetSpeed());
    }

    [Serializable]
    public class Parameters
    {
        [SerializeField] private TowerTargeter.Parameters targeterParameters;
        public TowerTargeter.Parameters TargeterParameters => targeterParameters;
        [SerializeField] private Damager.Parameters damagerParameters;
        public Damager.Parameters DamagerParameters => damagerParameters;
    }
}
