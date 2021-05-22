using CodingTest.Scripts.UI.Components.Buttons;
using CustomTools.ObjectPooling.Scripts.ObjectPool;
using UnityEngine;
using Zenject;

namespace CodingTest.Scripts.Dependency_Injection
{
    public class MainSceneInstaller : MonoInstaller
    {

        [SerializeField] private GameObject _gameManager;
        [SerializeField] private GameObject _objectPool;
        [SerializeField] private GameObject _userInterface;
        public override void InstallBindings()
        {
            Container.Bind<ObjectPooler>().FromComponentOn(_objectPool).AsSingle().NonLazy();
            Container.Bind<GameManager>().FromComponentOn(_gameManager).AsSingle().NonLazy();
            Container.Bind<UserInterfaceManager>().FromComponentOn(_userInterface).AsSingle().NonLazy();

        }
        
    }
}
