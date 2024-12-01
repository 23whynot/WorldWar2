using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Script.Enemy
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private int maxEnemies;

        private EnemyFactory _enemyFactory;

        [Inject]
        public void Construct(
            EnemyFactory enemyFactory)
        {
            _enemyFactory = enemyFactory;
        }
        
        private int _spawnTime = 2;
        private int _enemyActivated;

        public Transform GetSpawnPointTransform()
        {
            return transform;
        }

        public void EnemyDeactivated()
        {
            _enemyActivated -= 1;
        }

        private void Start()
        {
            StartCoroutine(SpawnProcess());
        }

        private IEnumerator SpawnProcess()
        {
            _enemyActivated = 0;
            while (true)
            {
                yield return new WaitForSeconds(_spawnTime);

                if (maxEnemies > _enemyActivated)
                {
                    _enemyActivated++;
                    _enemyFactory.SpawnRandomEnemy();
                }
            }
        }
    }
}