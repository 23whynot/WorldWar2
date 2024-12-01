using DG.Tweening;
using Script.Animation;
using Script.Constans;
using Script.Core;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Script.Hero
{
    public class HeroMovement : MonoBehaviour
    {
        [SerializeField] private CombatComponent combatComponent;
        [SerializeField] private AudioService audioService;
        [SerializeField] private Hero hero;
        [SerializeField] private Transform startPosition;
        [SerializeField] private Transform firePoint;
        [SerializeField] private Button upButton;
        [SerializeField] private Button downButton;
        [SerializeField] private Button fireButton;
        [SerializeField] private Animator animator;

        private AnimationController _animationController;
        private bool _iCanMove;
        private Tween _tween;
        private bool _isMovingUp;
        private bool _isMovingDown;

        private void Start()
        {
            _animationController = new AnimationController(animator);
            
            GoToStartPosition();

            AddEventTrigger(upButton, EventTriggerType.PointerDown, eventData => _isMovingUp = true);
            AddEventTrigger(upButton, EventTriggerType.PointerUp, eventData => _isMovingUp = false);

            AddEventTrigger(downButton, EventTriggerType.PointerDown, eventData => _isMovingDown = true);
            AddEventTrigger(downButton, EventTriggerType.PointerUp, eventData => _isMovingDown = false);

            fireButton.onClick.AddListener(Shoot);
        }

        private void Update()
        {
            if (_iCanMove)
            {
                if (Input.GetKey(KeyCode.W) || _isMovingUp)
                {
                    Move(Vector3.up);
                }
                else if (Input.GetKey(KeyCode.S) || _isMovingDown)
                {
                    Move(Vector3.down);
                }
                else if (Input.GetKeyDown(KeyCode.Space))
                {
                    Shoot();
                }
                else
                {
                    _animationController.StopAnimationShoot();
                    _animationController.StopAnimationRun();
                }
            }
        }

        private void Shoot()
        {
            _animationController.StartAnimationShoot();
            combatComponent.Shoot(firePoint);
            audioService.PlaySound(AudioConstans.Shoot);
        }

        private void GoToStartPosition()
        {
            _animationController.StartAnimationRun();
            _tween = transform.DOMove(startPosition.position, hero.Character.Speed)
                .SetEase(Ease.Linear)
                .OnComplete(() =>
                {
                    _iCanMove = true;
                    _animationController.StopAnimationRun();
                    _tween.Kill();
                });
        }

        private void Move(Vector3 vector)
        {
            transform.position += vector * hero.Character.Speed * Time.deltaTime;
            _animationController.StartAnimationRun();
        }

        private void AddEventTrigger(Button button, EventTriggerType triggerType, UnityEngine.Events.UnityAction<BaseEventData> action)
        {
            EventTrigger trigger = button.gameObject.GetComponent<EventTrigger>();
            if (trigger == null)
            {
                trigger = button.gameObject.AddComponent<EventTrigger>();
            }

            EventTrigger.Entry entry = new EventTrigger.Entry { eventID = triggerType };
            entry.callback.AddListener(action);
            trigger.triggers.Add(entry);
        }


        private void OnDestroy()
        {
            fireButton.onClick.RemoveAllListeners();
        }
    }
}

