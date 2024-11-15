using System.Collections;
using System.Collections.Generic;
using Script.Animation;
using UnityEngine;

public class ShootState : IState
{
    private AnimationController _animationController;
    private CombatComponent _combatComponent;
    
    
    public ShootState(AnimationController animationController, CombatComponent combatComponent)
    {
        _animationController = animationController;
        _combatComponent = combatComponent;
    }
    public void Enter()
    {
        _animationController.StartAnimationShoot();
        _combatComponent.Shoot();
    }

    public void Exit()
    {
        _animationController.StopAnimationShoot();
    }
}
