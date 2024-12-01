using Script.Core;
using Script.SaveLoadSystem;
using UnityEngine;
using Zenject;

namespace Script.Zenject
{
    public class SceneInstallerForMainMenu : MonoInstaller
    {
        [SerializeField] private PersonalBestScore personalBestScore;
        [SerializeField] private SaveLoadManager saveLoadManager;
    
        public override void InstallBindings()
        {
            Container.Bind<SaveLoadManager>().FromInstance(saveLoadManager).AsSingle();
            Container.BindInterfacesAndSelfTo<SaveLoad>().AsSingle();
            Container.Bind<PersonalBestScore>().FromInstance(personalBestScore).AsSingle();
        }
    }
}
