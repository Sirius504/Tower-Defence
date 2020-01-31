﻿using System;
using System.Collections;
using UnityEngine;
using Zenject;

public class WavesController : MonoBehaviour
{
    private EnemySpawner spawner;
    private Parameters parameters;
    private EnemyUpgrades enemyUpgrades;
    private int level = 1;

    [Inject]
    public void Construct(EnemySpawner spawner, Parameters parameters, EnemyUpgrades enemyUpgrades)
    {
        this.spawner = spawner;
        this.parameters = parameters;
        this.enemyUpgrades = enemyUpgrades;
    }

    private void Start()
    {
        spawner.AddWaveToSpawnList(CreateNewWave(level));
        spawner.OnWaveFinished += OnWaveFinished;
    }

    private void OnWaveFinished()
    {
        StartCoroutine(SpawnNewWaveAfterDelay());
    }

    private EnemyWaveInfo CreateNewWave(int level)
    {
        int enemiesCount = level + UnityEngine.Random.Range(0, parameters.EnemyCountModifier + 1);
        return new EnemyWaveInfo(enemiesCount, parameters.SpawnRate, enemyUpgrades.GetUpgraded(level - 1));
    }

    private IEnumerator SpawnNewWaveAfterDelay()
    {
        yield return new WaitForSeconds(parameters.DelayBetweenWaves);
        spawner.AddWaveToSpawnList(CreateNewWave(++level));
    }

    [Serializable]
    public class Parameters
    {
        [SerializeField] private float spawnRate;
        public float SpawnRate => spawnRate;
        [SerializeField] private float delayBetweenWaves;
        public float DelayBetweenWaves => delayBetweenWaves;
        [SerializeField] private int enemyCountModifier;
        public int EnemyCountModifier => enemyCountModifier;

        public void Validate()
        {
            if (spawnRate <= 0)
                throw new ArgumentOutOfRangeException("spawnRate", "Spawn Rate is less or equals zero.");
            if (delayBetweenWaves < 0)
                throw new ArgumentOutOfRangeException("delayBetweenWaves", "Delay between waves is less than zero.");            
        }
    }
}
