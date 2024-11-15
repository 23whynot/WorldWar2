using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Script.Animation;
using Script.Enemy;
using UnityEngine;

public class RunState : IState
{
    private Transform _enemyTransform;
    private AnimationController _animationController;
    private EnemyController _enemyController;
    private Character _character;
    
    private Tween _tween;
    
    public RunState(AnimationController controller, Transform enemyTransform, EnemyController enemyController, Character character)
    {
        _animationController = controller;
        _enemyTransform = enemyTransform;
        _enemyController = enemyController;
        _character = character;
    }
    public void Enter()
    {
        _animationController.StartAnimationRun();
        _tween = _enemyTransform.DOMove(_enemyController.GetRandomPosition(), _character.Speed).SetEase(Ease.Linear).OnComplete(() => {
            _tween.Kill();
        });
    }

    public void Exit()
    {
        _animationController.StopAnimationRun();
        _tween.Kill();
    }
}
