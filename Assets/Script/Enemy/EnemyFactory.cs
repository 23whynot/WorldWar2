using System.Collections.Generic;
using Script.Core;
using Script.Enemy;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    [SerializeField] private AudioService audioService;
    [SerializeField] private Score score;
    [SerializeField] private ObjectPool objectPool;
    [SerializeField] private EnemyController enemyController;
    [SerializeField] private EnemySpawner enemySpawner;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private Transform target;
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private List<Character> characterList;
    [SerializeField] private int preloadCount = 5;

    public void SpawnRandomEnemy()
    {
        Spawn<Enemy>(GetCharacter());
    }

    private void Start()
    {
        objectPool.RegisterPrefab<Enemy>(enemyPrefab, preloadCount);
    }

    private Character GetCharacter()
    {
        int randomIndex = Random.Range(0, characterList.Count);
        return characterList[randomIndex];
    }


    private T Spawn<T>(Character character) where T : Enemy
    {
        T enemy = objectPool.GetObject<T>();
        enemy.transform.position = spawnPoint.position;
        enemy.Init(character, enemyController, objectPool, target, enemySpawner, score, audioService);

        return enemy;
    }
}