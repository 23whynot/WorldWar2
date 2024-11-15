using System;
using UnityEngine;
using DG.Tweening;
using Script.Animation;
using Script.Constans;
using Script.Core;
using UnityEngine.Serialization;

public class HeroMovement : MonoBehaviour
{
    [SerializeField] private AudioService audioService;
    [SerializeField] private Hero hero;
    [SerializeField] private AnimationController animationController;
    [SerializeField] private Transform startPosition;
    [SerializeField] private CombatComponent combatComponent;
    
    private bool _iCanMove;
    private Tween _tween;
    

    private void Start()
    {
        GoToStartPosition();
    }

    private void Update()
    {
        if (_iCanMove)
        {
            if (Input.GetKey(KeyCode.W))
            {
                Move(Vector3.up);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                Move(Vector3.down);
            }
            else if (Input.GetKeyDown(KeyCode.Space))
            {
               Shoot();
            }
            else
            {
                animationController.StopAnimationShoot();
                animationController.StopAnimationRun();
            }
        }
    }

    private void Shoot()
    {
        animationController.StartAnimationShoot();
        combatComponent.Shoot();
        audioService.PlaySound(AudioConstans.Shoot);
    }

    private void GoToStartPosition()
    { 
        animationController.StartAnimationRun();
        _tween = transform.DOMove(startPosition.position, hero.Character.Speed)
        .SetEase(Ease.Linear)
        .OnComplete(() => {
            _iCanMove = true;
            animationController.StopAnimationRun();
            _tween.Kill();
        });
    }

    private void Move(Vector3 vector)
    {
        transform.position += vector * hero.Character.Speed * Time.deltaTime;
        animationController.StartAnimationRun();
    }
}
