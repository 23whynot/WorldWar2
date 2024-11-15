using System.Collections;
using UnityEngine;

namespace Script.Enemy
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private EnemyFactory factory;
        [SerializeField] private int maxEnemies;

        private int _spawnTimer = 2;
        private int _enemyActivated;

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
                yield return new WaitForSeconds(_spawnTimer);

                if (maxEnemies > _enemyActivated)
                {
                    _enemyActivated++;
                    factory.SpawnRandomEnemy();
                }
            }
        }
    }
}