using System;
using UnityEngine;
using Zenject;

public class Tower : MonoBehaviour
{
    private float lastShotTime;
    private Settings settings;
    private ShellRenderer shellRenderer;
    private Targeter<Enemy> targeter;
    private Damager damager;


    [Inject]
    public void Construct(Settings settings, ShellRenderer shellRenderer, TowerTargeter targeter, Damager damager)
    {        
        this.settings = settings;
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
    public class Settings
    {
        public TowerTargeter.Settings targeterSettings;
        public Damager.Parameters damagerSettings;
    }
}
