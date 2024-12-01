using System.Collections.Generic;
using Script.Core.ObjectPool;
using Script.Enemy;
using UnityEngine;
using Zenject;

public class EnemyFactory
{
    private EnemySpawner _enemySpawner;
    private ObjectPool _objectPool;
    private GameObject _enemyPrefab;
    private int _preloadCount = 5;
    private Character _character;
    
    
    [Inject]
    public void Construct(
        ObjectPool objectPool, 
        EnemySpawner enemySpawner)
    {
        _objectPool = objectPool;
        _enemySpawner = enemySpawner;
        
        _enemyPrefab = Resources.Load<GameObject>("Prefabs/" + ResourcesConstans.PrefabEnemy);
        
        _objectPool.RegisterPrefab<Enemy>(_enemyPrefab, _preloadCount);
        
        _character = Resources.Load<Character>("Characters/" + ResourcesConstans.CharacterEnemyGerman);
    }




    public void SpawnRandomEnemy()
    {
        Spawn<Enemy>(_character);
    }


    private T Spawn<T>(Character character) where T : Enemy
    {
        T enemy = _objectPool.GetObject<T>();
        enemy.transform.position = _enemySpawner.GetSpawnPointTransform().position;
        enemy.Init(character);

        return enemy;
    }
}