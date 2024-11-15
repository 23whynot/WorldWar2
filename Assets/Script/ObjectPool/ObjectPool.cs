using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class ObjectPool : MonoBehaviour
{
    private Dictionary<Type, List<IPoolableObject>> _pools = new Dictionary<Type, List<IPoolableObject>>();
    private Dictionary<Type, GameObject> _prefabs = new Dictionary<Type, GameObject>();

    public void RegisterPrefab<T>(GameObject prefab, int preLoadCount) where T : IPoolableObject
    {
        Type objectType = typeof(T);

        if (!_prefabs.ContainsKey(objectType))
        {
            _prefabs.Add(objectType, prefab);
        }

        if (!_pools.TryGetValue(objectType, out List<IPoolableObject> pool))
        {
            pool = new List<IPoolableObject>();
            _pools[objectType] = pool;
        }

        for (int i = 0; i < preLoadCount; i++)
        {
            if (pool.Count < preLoadCount)
            {
                GameObject newObjGameObject = Instantiate(prefab);
                IPoolableObject newObj = newObjGameObject.GetComponent<IPoolableObject>();

                if (newObj != null)
                {
                    newObj.Deactivate();
                    pool.Add(newObj);
                }
            }
        }
    }

    public T GetObject<T>() where T : IPoolableObject
    {
        Type objectType = typeof(T);

        if (!_pools.TryGetValue(objectType, out List<IPoolableObject> pool))
        {
            pool = new List<IPoolableObject>();
            _pools[objectType] = pool;
        }

        foreach (var obj in pool.Where(obj => !obj.IsActive))
        {
            obj.Activate();

            return (T)obj;
        }

        if (_prefabs.TryGetValue(objectType, out GameObject prefab))
        {
            GameObject newObjGameObject = Instantiate(prefab);

            var newObj = newObjGameObject.GetComponent<IPoolableObject>();
            if (newObj != null)
            {
                pool.Add(newObj);
                newObj.Activate();

                return (T)newObj;
            }

            Debug.LogError($"Prefab for type {objectType} does not implement IGameObject interface");

            return default;
        }

        Debug.LogError($"No prefab registered for type {objectType}");

        return default;
    }

    public void ReturnObject(IPoolableObject obj)
    {
        obj.Deactivate();
    }
}