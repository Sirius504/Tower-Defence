using System;
using Zenject;

public class KilledEnemyCounter
{
    private readonly EnemySpawner enemySpawner;

    public int Killed { get; private set; } = 0;
    public event Action<int> OnChange;

    [Inject]
    public KilledEnemyCounter(EnemySpawner enemySpawner)
    {
        this.enemySpawner = enemySpawner;
        enemySpawner.OnEnemySpawned += OnEnemySpawned;
    }

    private void OnEnemySpawned(Enemy enemy)
    {
        enemy.Health.OnHealthZero += OnEnemyKilled;
    }

    private void OnEnemyKilled()
    {
        Killed++;
        OnChange?.Invoke(Killed);
    }
}

