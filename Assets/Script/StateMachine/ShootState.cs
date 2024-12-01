using System.Collections;
using System.Collections.Generic;
using Script.Animation;
using UnityEngine;

public class ShootState : IState
{
    private AnimationController _animationController;
    private CombatComponent _combatComponent;
    private Transform _firePoint;
    
    
    public ShootState(AnimationController animationController, CombatComponent combatComponent, Transform firePoint)
    {
        _animationController = animationController;
        _combatComponent = combatComponent;
        _firePoint = firePoint;
    }
    public void Enter()
    {
        _animationController.StartAnimationShoot();
        _combatComponent.Shoot(_firePoint);
    }

    public void Exit()
    {
        _animationController.StopAnimationShoot();
    }
}
