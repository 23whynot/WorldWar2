using System.Collections;
using DG.Tweening;
using UnityEngine;
using System;
using Script.Animation;
using Script.Constans;
using Script.Core;
using Script.Enemy;

public class EnemyBehavior : MonoBehaviour
{
    private AudioService _audioService;
    private Enemy _enemy;
    private StateMachine _stateMachine;
    private AnimationController _animationController;
    private EnemyController _enemyController;
    private CombatComponent _combatComponent;
    private Character _character;

    private Coroutine _routine;
    private Coroutine _deathCoroutine;
    private Tween _tween;

    private int _numberOfRuns = 1;
    private int _runTime = 1;
    private int _idleTime = 1;
    private float _shootTime = 0.3f;
    private int _deathTime = 2;

    public void Init(AnimationController animationController, EnemyController enemyController, Character character,
        CombatComponent combatComponent, Enemy enemy, AudioService audioService)
    {
        _animationController = animationController;
        _enemyController = enemyController;
        _character = character;
        _combatComponent = combatComponent;
        _enemy = enemy;
        _audioService = audioService;

        _stateMachine = new StateMachine();
    }

    public void Death()
    {
        if (_routine != null)
        {
            StopCoroutine(_routine);
            _routine = null;
        }
        _tween?.Kill();
        
        _stateMachine.ChangeState(new DeathState(_animationController));
        _deathCoroutine = StartCoroutine(DeathCoroutine());
    }

    private void Shoot()
    {
        _stateMachine.ChangeState(new ShootState(_animationController, _combatComponent));
        _audioService.PlaySound(AudioConstans.Shoot);
    }

    private void Run() =>
        _stateMachine.ChangeState(new RunState(_animationController, transform, _enemyController, _character));


    private void Idle() =>
        _stateMachine.ChangeState(new IdleState(_animationController));

    private void MoveToStartPosition()
    {
        _animationController.StartAnimationRun();
        _tween = transform.DOMove(_enemyController.GetRandomPosition(), _character.Speed).SetEase(Ease.Linear)
            .OnComplete(() =>
            {
                _tween.Kill();
                _routine = StartCoroutine(Routine());
            });
    }

    public void StartBehavior()
    {
        MoveToStartPosition();
    }

    public void StopBehavior()
    {
        if (_routine != null)
        {
            StopCoroutine(_routine);
            _routine = null;
        }
    }

    private IEnumerator Routine()
    {
        while (true)
        {
            for (int i = 0; i < _numberOfRuns; i++)
            {
                Run();
                yield return new WaitForSeconds(_runTime);
            }

            Idle();
            yield return new WaitForSeconds(_idleTime);
            Shoot();
            yield return new WaitForSeconds(_shootTime);
        }
    }

    private IEnumerator DeathCoroutine()
    {
        _animationController.StartAnimationDeath();
        yield return new WaitForSeconds(_deathTime);
        _enemy.Deactivate();

        if (_deathCoroutine != null)
        {
            StopCoroutine(_deathCoroutine);
            _deathCoroutine = null;
        }
    }
}