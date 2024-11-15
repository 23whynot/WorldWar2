using Script.Core;
using UnityEngine;

public class Hero : MonoBehaviour
{
    [SerializeField] private Health health;
    [SerializeField] private Character character;
    [SerializeField] private Animator animator;
    [SerializeField] private ObjectPool objectPool;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform target;
    [SerializeField] private Transform firePoint;
    [SerializeField] private CombatComponent combatComponent;

    private void Awake()
    {
        combatComponent.Init(objectPool, bulletPrefab, target, firePoint);
    }
    
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent<Bullet>(out var bullet))
        {
            health.Decrease();
        }
    }
    
    public Character Character => character; 
}
