using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class Tower : MonoBehaviour
{
    private float lastShotTime;
    private Settings settings;
    private ShellRenderer shellRenderer;
    private Targeter<Enemy> targeter;

    public event Action<Vector3> OnShot;

    [Inject]
    public void Construct(Settings settings, ShellRenderer shellRenderer, TowerTargeter targeter)
    {        
        this.settings = settings;
        this.shellRenderer = shellRenderer;
        this.targeter = targeter;
        targeter.OnTargetAcquired += ShootAt;
        lastShotTime = Time.time;
    }

    private void ShootAt(Enemy target)
    {        
        var toTarget = target.transform.position - transform.position;
        target.TakeDamage(settings.damage);
        OnShot?.Invoke(target.transform.position);
        shellRenderer.DrawShotAt(target.transform.position, target.GetSpeed());
    }

    [Serializable]
    public class Settings
    {
        public TowerTargeter.Settings targeterSettings;
        public float damage = 1f;
    }
}
