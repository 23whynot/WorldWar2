using UnityEngine;

namespace Script.Animation
{
    public class AnimationController
    {
        private Animator _animator;
        public AnimationController(Animator animator)
        {
            _animator = animator;
        }
        public void StartAnimationIdle()
        {
            _animator.SetBool(Constans.StateConstans.IS_RUNING, false);
            _animator.SetBool(Constans.StateConstans.IS_DEAD, false);
            _animator.SetBool(Constans.StateConstans.IS_SHOOTING, false);
        }
    
        public void StartAnimationRun() 
        {
            _animator.SetBool(Constans.StateConstans.IS_RUNING, true);
        }

        public void StopAnimationRun()
        {
            _animator.SetBool(Constans.StateConstans.IS_RUNING, false);
        }

        public void StartAnimationDeath()
        {
            _animator.SetBool(Constans.StateConstans.IS_DEAD, true);
        }

        public void StopAnimationDeath()
        {
            _animator.SetBool(Constans.StateConstans.IS_DEAD, false);
        }

        public void StartAnimationShoot()
        {
            _animator.SetBool(Constans.StateConstans.IS_SHOOTING, true);
        }

        public void StopAnimationShoot()
        {
            _animator.SetBool(Constans.StateConstans.IS_SHOOTING, false);
        }
    }
}
