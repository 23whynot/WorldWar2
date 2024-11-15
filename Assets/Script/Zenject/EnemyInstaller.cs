using Script.Enemy;
using UnityEngine;
using Zenject;

public class EnemyInstaller : MonoInstaller
{
    [SerializeField] private EnemyController enemyController;
    public override void InstallBindings()
    {
    }
}