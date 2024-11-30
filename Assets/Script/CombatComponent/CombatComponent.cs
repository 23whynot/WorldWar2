using System.Collections;
using System.Collections.Generic;
using Script.Core;
using UnityEngine;

public class CombatComponent : MonoBehaviour
{
    [SerializeField] private int _preLoadCount = 10;
    
    private AudioService _audioService;
    private ObjectPool _objectPool;
    private GameObject _bulletPrefab;
    private Transform _target;
    private Transform _firePoint;
    

    public void Init(ObjectPool objectPool, GameObject bulletPrefab, Transform target, Transform firePoint)
    {
        _objectPool = objectPool;
        _bulletPrefab = bulletPrefab;
        _target = target;
        _firePoint = firePoint;
        
    }
    
    private void Start()
    {
        _objectPool.RegisterPrefab<Bullet>(_bulletPrefab, _preLoadCount);
    }

    public void Shoot()
    {
       Bullet bullet = _objectPool.GetObject<Bullet>();
       bullet.transform.position = _firePoint.position;
       bullet.Init(_target);
    }
   
}
