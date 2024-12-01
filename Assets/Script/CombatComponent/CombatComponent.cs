using Script.Core;
using Script.Core.ObjectPool;
using UnityEngine;

using Zenject;

public class CombatComponent : MonoBehaviour
{
    [SerializeField] private int preLoadCount = 10;
    
    private AudioService _audioService;
    private ObjectPool _objectPool;
    private GameObject _bulletPrefab;
    private Transform _target;
    private Transform _firePoint;
    
    [Inject]
    public void Construct(
        ObjectPool objectPool)
    {
        _objectPool = objectPool;
        _bulletPrefab = Resources.Load<GameObject>("Prefabs/" + ResourcesConstans.PrefabBullet);
    }


    private void Start()
    {
        _objectPool.RegisterPrefab<Bullet>(_bulletPrefab, preLoadCount);
    }



    public void SetTarget(Transform target)
    {
        _target = target;
    }

    public void Shoot(Transform firePoint) 
    {
       Bullet bullet = _objectPool.GetObject<Bullet>();
       bullet.transform.position = firePoint.position;
       bullet.StartMove(_target);
    }
   
}
