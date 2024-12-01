using UnityEngine;
using DG.Tweening;

public class Bullet : MonoBehaviour, IPoolableObject
{
    [SerializeField] private int bulletSpeed;

    private Tween _tween;
    
    public bool IsActive { get; private set; }

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

    public void StartMove(Transform target)
    {
        _tween = transform.DOMoveX(target.position.x, bulletSpeed)
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