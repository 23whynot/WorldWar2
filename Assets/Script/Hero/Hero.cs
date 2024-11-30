using System;
using Script.Core;
using UnityEngine;

public class Hero : MonoBehaviour
{
    [SerializeField] private AudioService audioService;
    [SerializeField] private Health health;
    [SerializeField] private Character character;
    [SerializeField] private Animator animator;
    [SerializeField] private ObjectPool objectPool;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform target;
    [SerializeField] private Transform firePoint;
    [SerializeField] private CombatComponent combatComponent;

    public Character Character => character;

    private void Awake()
    {
        combatComponent.Init(objectPool, bulletPrefab, target, firePoint);
    }

    private void Start()
    {
        health.OnDeath += Dead;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent<Bullet>(out var bullet))
        {
            audioService.PlaySound("Damage");
            health.Decrease();
        }
    }

    private void Dead()
    {
        animator.SetBool("isDead", true);
    }

    private void OnDisable()
    {
        health.OnDeath -= Dead;
    }
}
