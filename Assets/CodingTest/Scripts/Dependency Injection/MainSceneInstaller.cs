using CustomTools.ObjectPooling.Scripts.ObjectPool;
using UnityEngine;
using Zenject;

namespace CodingTest.Scripts.Dependency_Injection
{
    public class MainSceneInstaller : MonoInstaller
    {

        [SerializeField] private GameObject _gameManager;
        [SerializeField] private GameObject _objectPool;
        public override void InstallBindings()
        {
            Container.Bind<ObjectPooler>().FromComponentOn(_objectPool).AsSingle().NonLazy();
            Container.Bind<GameManager>().FromComponentOn(_gameManager).AsSingle().NonLazy();
        }
        
    }
}
