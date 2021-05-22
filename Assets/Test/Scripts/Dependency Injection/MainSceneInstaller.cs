using System.Collections;
using System.Collections.Generic;
using CustomTools.ObjectPooling.Scripts.ObjectPool;
using UnityEngine;
using Zenject;

public class MainSceneInstaller : MonoInstaller
{

    public override void InstallBindings()
    {
        Container.Bind<ObjectPooler>().FromComponentInChildren().AsSingle().NonLazy();
    }
}
