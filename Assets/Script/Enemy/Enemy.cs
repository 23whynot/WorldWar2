using DG.Tweening;
using Script.Animation;
using Script.Constans;
using Script.Core;
using Script.Hero;
using UnityEngine;
using Zenject;

namespace Script.Enemy
{
    public class Enemy : MonoBehaviour, IPoolableObject
    {
        [SerializeField] private EnemyBehavior enemyBehavior;
        [SerializeField] private CombatComponent combatComponent;
        [SerializeField] private Transform firePoint;
        [SerializeField] private CapsuleCollider2D capsuleCollider;


        private AnimationController _animationController;
        private EnemyPositionContainer _enemyPositionContainer;
        private EnemySpawner _spawner;
        private GameScore _gameScore;
        private AudioService _audioService;
        private HeroSpawner _heroSpawner;


        [Inject]
        public void Construct(
            EnemyPositionContainer enemyPositionContainer,
            EnemySpawner enemySpawner,
            GameScore gameScore,
            AudioService audioService,
            HeroSpawner heroSpawner)
        {
            _enemyPositionContainer = enemyPositionContainer;
            _spawner = enemySpawner;
            _gameScore = gameScore;
            _audioService = audioService;
            _heroSpawner = heroSpawner;
        }


        private Character _character;
        private Tweener _tween;
        private Coroutine _deathCoroutine;


        public bool IsActive { get; private set; }

        private void Start()
        {
            combatComponent.SetTarget(_heroSpawner.GetHeroSpawnPointTransform());
        }

        public void Init(Character character)
        {
            _character = character;

            enemyBehavior.Init(_character, combatComponent, this, _enemyPositionContainer, _audioService);
        
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
            _audioService.PlaySound(AudioConstans.Damage);
            capsuleCollider.enabled = false;
            _gameScore.Increase(_character.ScoreCost);
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
}