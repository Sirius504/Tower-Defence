using System;
using System.Linq;
using UnityEngine;
using Zenject;

public class TowerTargeter : Targeter<Enemy>
{
    private Parameters settings;
    private float lastShotTime;

    [Inject]
    public void Construct(Parameters settings)
    {
        this.settings = settings;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > lastShotTime + settings.fireRate)
        {
            CurrentTarget = GetClosestEnemyInRadius();
            if (CurrentTarget == null)
                return;
            InvokeOnTargetAcquired(CurrentTarget);
            lastShotTime = Time.time;
        }
    }

    private Enemy GetClosestEnemyInRadius()
    {
        var collidersInRadius = Physics.OverlapSphere(transform.position, settings.radius)
            // Sometimes physics engine detects collision with freshly spawned object
            // while it's at (0, 0, 0), checking again here that collider 
            // within radius.
            .Where(c => (c.transform.position - transform.position).sqrMagnitude < Mathf.Pow(settings.radius, 2))
            .OrderBy(c => (c.transform.position - transform.position).sqrMagnitude);

        foreach (var collider in collidersInRadius)
        {
            var enemyComponent = collider.GetComponent<Enemy>();
            if (enemyComponent != null)
                return enemyComponent;
        }
        return null;
    }

    [Serializable]
    public class Parameters
    {
        public float radius = 10f;
        public float fireRate = 1f;
    }
}
