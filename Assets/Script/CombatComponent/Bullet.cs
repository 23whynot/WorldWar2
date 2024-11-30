using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class Bullet : MonoBehaviour, IPoolableObject
{
    [SerializeField] private int bulletSpeed;

    private Tween _tween;
    private Transform _target;
    private ObjectPool _pool;
    
    public bool IsActive { get; private set; }

    public void Init(Transform target)
    {
        _target = target;

        StartMove();
    }

    public void Activate()
    {
        gameObject.SetActive(true);
        IsActive = true;
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
        IsActive = false;
    }

    private void StartMove()
    {
        _tween = transform.DOMoveX(_target.position.x, bulletSpeed)
            .SetEase(Ease.Linear)
            .OnComplete(() =>
            {
                Deactivate();
                _tween.Kill();
            });
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Deactivate();
    }
}