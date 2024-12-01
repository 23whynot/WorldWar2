using System.Collections.Generic;
using Script.Core;
using Script.Core.ObjectPool;
using Script.Enemy;
using Script.Hero;
using Script.SaveLoadSystem;
using Script.UI;
using UnityEngine;
using Zenject;

namespace Script.Zenject
{
    public class SceneInstaller : MonoInstaller
    {
        [SerializeField] private SaveLoadManager saveLoadManager;
        [SerializeField] private ScoreUI scoreUI;
        [SerializeField] private HealthUI healthUI;
        [SerializeField] private EnemyPositionContainer enemyPositionContainer;
        [SerializeField] private EnemySpawner enemySpawner;
        [SerializeField] private AudioService audioService;
        [SerializeField] private HeroSpawner heroSpawner;
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private GameObject enemyPrefab;
        [SerializeField] private List<Character> characters;
        
        
        
        public override void InstallBindings()
        {
            Container.Bind<GameScore>().AsSingle();
            Container.Bind<SaveLoad>().AsSingle();
            Container.Bind<EnemyFactory>().AsSingle();
            Container.Bind<ObjectPool>().AsSingle();

            Container.Bind<InputController>().FromComponentInHierarchy().AsSingle();

            Container.Bind<SaveLoadManager>().FromInstance(saveLoadManager).AsSingle();
            Container.Bind<ScoreUI>().FromInstance(scoreUI).AsSingle();
            Container.Bind<HealthUI>().FromInstance(healthUI).AsSingle();
            Container.Bind<EnemyPositionContainer>().FromInstance(enemyPositionContainer).AsSingle();
            Container.Bind<EnemySpawner>().FromInstance(enemySpawner).AsSingle();
            Container.Bind<AudioService>().FromInstance(audioService).AsSingle();
            Container.Bind<HeroSpawner>().FromInstance(heroSpawner).AsSingle();
            Container.Bind<Health>().AsSingle();
        }
    }
}