using System;
using System.Collections;
using System.Collections.Generic;
using CodingTest.Scripts.Structs;
using CustomTools.ObjectPooling.Scripts.ObjectPool;
using UnityEngine;
using Zenject;

public class GameManager : MonoBehaviour
{

    [SerializeField]
    public LimitedArea AreaLimit = new LimitedArea(200, 200, 200);

    [Inject] private UserInterfaceManager _uiManager;
    [Inject] private ObjectPooler _pooler;
    private void Awake()
    {
        _uiManager.SpawnCubeButtonClicked += OnSpawnCubeAction;
    }

    private void OnDestroy()
    {
        _uiManager.SpawnCubeButtonClicked -= OnSpawnCubeAction;
    }

    private void OnSpawnCubeAction()
    {
        ISpawner spawner = new CubeSpawner(_pooler,PooledObjectType.Cube);
        spawner.Spawn();
    }
}
