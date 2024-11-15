using System.Collections;
using System.Collections.Generic;
using Script.Animation;
using UnityEngine;

public class DeathState : IState
{
    private AnimationController _animationController;
    public DeathState(AnimationController animationController)
    {
        _animationController = animationController;
    }

    public void Enter()
    {
        _animationController.StartAnimationDeath();
    }

    public void Exit()
    {
        _animationController.StopAnimationDeath();
    }
}
