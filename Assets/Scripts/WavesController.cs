using System;
using System.Collections;
using UnityEngine;
using Zenject;

public class WavesController : MonoBehaviour
{
    private EnemySpawner spawner;
    private Settings settings;
    private int level = 1;

    [Inject]
    public void Construct(EnemySpawner spawner, Settings settings)
    {
        this.spawner = spawner;
        this.settings = settings;
        spawner.AddWaveToSpawnList(CreateNewWave(level));
        spawner.OnWaveFinished += OnWaveFinished;
    }

    private void OnWaveFinished()
    {
        StartCoroutine(SpawnNewWaveAfterDelay());
    }

    private EnemyWaveInfo CreateNewWave(int level)
    {
        int enemiesCount = level + UnityEngine.Random.Range(0, settings.enemyCountModifier + 1);
        return new EnemyWaveInfo(enemiesCount, settings.spawnRate,  null);
    }

    private IEnumerator SpawnNewWaveAfterDelay()
    {
        yield return new WaitForSeconds(settings.delayBetweenWaves);
        spawner.AddWaveToSpawnList(CreateNewWave(++level));
    }

    [Serializable]
    public class Settings
    {
        public float spawnRate;
        public float delayBetweenWaves;
        public int enemyCountModifier;
    }
}
