using System;

[Serializable]
public class EnemyWaveInfo
{
    public int Amount { get; }
    public float SpawnRate { get; }
    public Enemy.Settings EnemyParameters { get; }

    public EnemyWaveInfo(int enemiesCount, float spawnRate, Enemy.Settings enemyParameters)
    {
        this.Amount = enemiesCount;
        this.SpawnRate = spawnRate;
        this.EnemyParameters = enemyParameters;
    }
}