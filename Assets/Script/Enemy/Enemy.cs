using DG.Tweening;
using Script.Animation;
using Script.Core;
using Script.Enemy;
using UnityEngine;

public class Enemy : MonoBehaviour, IPoolableObject
{
    [SerializeField] private EnemyBehavior enemyBehavior;
    [SerializeField] private AnimationController animationController;
    [SerializeField] private CombatComponent combatComponent;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private CapsuleCollider2D capsuleCollider;


    private Score _score;
    private EnemySpawner _spawner;
    private Character _character;
    private Tweener _tween;
    private Coroutine _deathCoroutine;
    
    public bool IsActive { get; private set; }

    public void Init(Character character, EnemyController enemyController, ObjectPool objectPool, Transform target, EnemySpawner enemySpawner, Score score, AudioService audioService)
    {
        _character = character;
        _spawner = enemySpawner;
        _score = score;

        combatComponent.Init(objectPool, bulletPrefab, target, firePoint);
        
        enemyBehavior.Init(animationController, enemyController, _character, combatComponent, this, audioService);
        
        enemyBehavior.StartBehavior();
    }


    public void Activate()
    {
        capsuleCollider.enabled = true;
        gameObject.SetActive(true);
        IsActive = true;
    }

    public void Deactivate()
    {
        if (_deathCoroutine != null)
        {
            StopCoroutine(_deathCoroutine);
            _deathCoroutine = null;
        }
        enemyBehavior.StopBehavior();
        gameObject.SetActive(false);
        IsActive = false;
    }


    private void OnHit()
    {
        capsuleCollider.enabled = false;
        _score.Increase(_character.ScoreCost);
        enemyBehavior.Death();
        _spawner.EnemyDeactivated();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent<Bullet>(out var bullet))
        {
            OnHit();
        }
    }
}