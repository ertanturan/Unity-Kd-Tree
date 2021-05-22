using System;
using System.Collections;
using System.Collections.Generic;
using CodingTest.Scripts.Structs;
using CodingTest.Scripts.UI.Components.Buttons;
using CustomTools.ObjectPooling.Scripts.ObjectPool;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    #region Properties and Fields

    [Header("Area Limit")] [SerializeField]
    public LimitedArea AreaLimit = new LimitedArea(200, 200, 200);

    [Inject] private UserInterfaceManager _uiManager;
    [Inject] private ObjectPooler _pooler;

    [Header("Utility")] 
    [SerializeField] private int _initialAmountOfCubes = 100;

    private WaitForSeconds _waitFor = new WaitForSeconds(0.1f);
    
    #endregion


    #region Built-in Methods
    private void Awake()
    {
        _uiManager.SpawnCubeButtonClicked += OnSpawnCubeAction;
    }
    
    private void OnDestroy()
    {
        _uiManager.SpawnCubeButtonClicked -= OnSpawnCubeAction;
    }


    private void Start()
    {
        StartCoroutine(SpawnInitialCubesWithDelay());
    }

    #endregion


    #region Custom Methods

    

    private void OnSpawnCubeAction()
    {
      SpawnCubeAtOrigin();
    }

    private IEnumerator SpawnInitialCubesWithDelay() // I've put the delay because, the object pooler's cycle was also in Start.
    //so they were colliding.
    {
        yield return _waitFor;
        
        for (int i = 0; i < _initialAmountOfCubes; i++)
        {
            SpawnCubeAtArbitraryPositionInsideLimitedArea();
        }
    }

    private void SpawnCubeAtOrigin()
    {
        ISpawner spawner = new CubeSpawner(_pooler, PooledObjectType.Cube);
        spawner.Spawn();
    }

    private void SpawnCubeAtArbitraryPositionInsideLimitedArea()
    {
        ISpawner spawner = new CubeSpawner(_pooler, PooledObjectType.Cube);
        spawner.SpawnAtDefinition(GenerateNewRandomPositionInsideLimitedArea(),Quaternion.identity);
    }
    
    public Vector3 GenerateNewRandomPositionInsideLimitedArea()
    {
        return new Vector3(
            Random.Range(0, AreaLimit.X),
            Random.Range(0, AreaLimit.Y),
            Random.Range(0, AreaLimit.Z)
        );
    }

    #endregion

  
}