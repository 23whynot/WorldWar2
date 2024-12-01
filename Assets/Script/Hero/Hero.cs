using Script.Core;
using Script.Enemy;
using UnityEngine;
using Zenject;

namespace Script.Hero
{
    public class Hero : MonoBehaviour
    {
        [SerializeField] private Character character;
        [SerializeField] private Animator animator;
        [SerializeField] private Transform target;
        [SerializeField] private Transform firePoint;
        [SerializeField] private CombatComponent combatComponent;

        private AudioService _audioService;
        private EnemySpawner _enemySpawner;
        private Health _health;

        [Inject]
        public void Construct(AudioService audioService, EnemySpawner enemySpawner, Health health)
        {
            _audioService = audioService;
            _enemySpawner = enemySpawner;
            _health = health;
        }
        

        public Character Character => character;

        private void Awake()
        {
            combatComponent.SetTarget(_enemySpawner.GetSpawnPointTransform());
        }

        private void Start()
        {
            _health.OnDeath += Dead;
        }

        private void OnTriggerEnter2D(Collider2D HeroColider)
        {
            if (HeroColider.TryGetComponent<Bullet>(out var bullet))
            {
                _audioService.PlaySound("Damage");
                _health.Decrease();
            }
        }

        private void Dead()
        {
            animator.SetBool("isDead", true);
        }

        private void OnDisable()
        {
            _health.OnDeath -= Dead;
        }
    }
}
