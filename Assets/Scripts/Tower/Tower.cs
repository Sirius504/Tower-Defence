using System;
using System.Linq;
using UnityEngine;
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

    // Update is called once per frame
    //private void Update()
    //{
    //    if (Time.time > lastShotTime + settings.fireRate)
    //    {
    //        var target = GetClosestEnemyInRadius();
    //        if (target == null)
    //            return;
    //        ShootAt(target);
    //        lastShotTime = Time.time;
    //    }
    //}

    //private Enemy GetClosestEnemyInRadius()
    //{
    //    var collidersInRadius = Physics.OverlapSphere(transform.position, settings.radius)
    //        // Sometimes physics engine detects collision with freshly spawned object
    //        // while it's at (0, 0, 0), checking again here that collider 
    //        // within radius.
    //        .Where(c => (c.transform.position - transform.position).sqrMagnitude < Mathf.Pow(settings.radius, 2))
    //        .OrderBy(c => (c.transform.position - transform.position).sqrMagnitude);
        
    //    foreach (var collider in collidersInRadius)
    //    {
    //        var enemyComponent = collider.GetComponent<Enemy>();
    //        if (enemyComponent != null)            
    //            return enemyComponent;            
    //    }
    //    return null;
    //}

    private void ShootAt(Enemy target)
    {
        var toTarget = target.transform.position - transform.position;
        target.TakeDamage(settings.damage);
        OnShot?.Invoke(target.transform.position);
        shellRenderer.DrawShotAt(target.transform.position);
    }

    [Serializable]
    public class Settings
    {
        public TowerTargeter.Settings targeterSettings;
        public float damage = 1f;
    }
}
