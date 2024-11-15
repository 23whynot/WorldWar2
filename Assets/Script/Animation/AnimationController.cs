using UnityEngine;

namespace Script.Animation
{
    public class AnimationController : MonoBehaviour
    {
        [SerializeField] private Animator animator;

        public void StartAnimationIdle()
        {
            animator.SetBool(Constans.StateConstans.IS_RUNING, false);
            animator.SetBool(Constans.StateConstans.IS_DEAD, false);
            animator.SetBool(Constans.StateConstans.IS_SHOOTING, false);
        }
    
        public void StartAnimationRun() 
        {
            animator.SetBool(Constans.StateConstans.IS_RUNING, true);
        }

        public void StopAnimationRun()
        {
            animator.SetBool(Constans.StateConstans.IS_RUNING, false);
        }

        public void StartAnimationDeath()
        {
            animator.SetBool(Constans.StateConstans.IS_DEAD, true);
        }

        public void StopAnimationDeath()
        {
            animator.SetBool(Constans.StateConstans.IS_DEAD, false);
        }

        public void StartAnimationShoot()
        {
            animator.SetBool(Constans.StateConstans.IS_SHOOTING, true);
        }

        public void StopAnimationShoot()
        {
            animator.SetBool(Constans.StateConstans.IS_SHOOTING, false);
        }
    }
}
