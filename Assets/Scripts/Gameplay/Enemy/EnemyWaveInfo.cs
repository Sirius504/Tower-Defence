using System;

[Serializable]
public class EnemyWaveInfo
{
    public int Amount { get; }
    public float SpawnRate { get; }
    public Enemy.Parameters EnemyParameters { get; }

    public EnemyWaveInfo(int enemiesCount, float spawnRate, Enemy.Parameters enemyParameters)
    {
        this.Amount = enemiesCount;
        this.SpawnRate = spawnRate;
        this.EnemyParameters = enemyParameters;
    }
}