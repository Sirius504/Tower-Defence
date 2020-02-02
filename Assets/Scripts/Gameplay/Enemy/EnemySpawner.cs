using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace TowerDefence.Gameplay.EnemySystem
{
    public class EnemySpawner : MonoBehaviour
    {
        private EnemyWaveInfo currentWaveInfo;
        private Queue<EnemyWaveInfo> wavesQueue;
        private float lastSpawnTime;
        private int spawnedFromCurrentWave = 0;
        private Enemy.Factory enemyFactory;

        public event Action OnWaveFinished;
        public event Action<Enemy> OnEnemySpawned;

        [Inject]
        public void Construct(Enemy.Factory enemyFactory)
        {
            this.enemyFactory = enemyFactory;
            wavesQueue = new Queue<EnemyWaveInfo>();
            lastSpawnTime = Time.time;
        }

        public void AddWaveToSpawnList(EnemyWaveInfo newWave)
        {
            wavesQueue.Enqueue(newWave);
        }

        private void Update()
        {
            if (currentWaveInfo == null && wavesQueue.Count == 0)
                return;

            currentWaveInfo = wavesQueue.Peek();

            if (Time.time > lastSpawnTime + currentWaveInfo.SpawnRate)
                SpawnEnemy(currentWaveInfo.EnemyParameters);
        }

        private void OnWaveSpawnFinished()
        {
            spawnedFromCurrentWave = 0;
            currentWaveInfo = null;
            wavesQueue.Dequeue();
            OnWaveFinished?.Invoke();
        }

        private void SpawnEnemy(Enemy.Parameters enemyParameters)
        {
            var newEnemy = enemyFactory.Create();
            newEnemy.SetParameters(enemyParameters);
            newEnemy.transform.position = transform.position;
            newEnemy.transform.rotation = transform.rotation;
            lastSpawnTime = Time.time;
            OnEnemySpawned?.Invoke(newEnemy);
            if (++spawnedFromCurrentWave >= currentWaveInfo.Amount)
                OnWaveSpawnFinished();
        }
    } 
}
