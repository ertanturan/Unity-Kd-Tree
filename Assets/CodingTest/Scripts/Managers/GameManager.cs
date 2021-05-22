using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CodingTest.Scripts.Game;
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

    [Header("Utility")] [SerializeField] private int _initialAmountOfCubes = 100;

    private KdTree<FreeRoam> _freeRoamingCubes = new KdTree<FreeRoam>();

    public KdTree<FreeRoam> FreeRoamingCubes
    {
        get
        {
            return _freeRoamingCubes;
        }
    }

    private List<GameObject> _freeRoamsList = new List<GameObject>();
    private WaitForSeconds _waitFor = new WaitForSeconds(0.1f);

    #endregion


    #region Built-in Methods

    private void Awake()
    {
        _uiManager.SpawnCubeButtonClicked += OnSpawnCubeAction;
        _uiManager.BulkSpawnButtonClicked += OnBulkSpawnCubeAction;
        _uiManager.BulkDespawnButtonClicked += OnBulkDespawnCubeAction;
    }


    private void OnDestroy()
    {
        _uiManager.SpawnCubeButtonClicked -= OnSpawnCubeAction;
        _uiManager.BulkSpawnButtonClicked -= OnBulkSpawnCubeAction;
        _uiManager.BulkDespawnButtonClicked -= OnBulkDespawnCubeAction;
    }


    private void Start()
    {
        StartCoroutine(SpawnInitialCubesWithDelay());
    }

    #endregion


    #region Custom Methods

    private void OnSpawnCubeAction()
    {
        SpawnCubeAtArbitraryPositionInsideLimitedArea();
    }

    private IEnumerator
        SpawnInitialCubesWithDelay() // I've put the delay because, the object pooler's cycle was also in Start.
        //so they were colliding.
    {
        yield return _waitFor;


        BulkSpawnCubes(_initialAmountOfCubes);
    }


    private void SpawnCubeAtArbitraryPositionInsideLimitedArea()
    {
        ISpawner spawner = new CubeSpawner(_pooler, PooledObjectType.Cube);
        spawner.SpawnAtDefinition(GenerateNewRandomPositionInsideLimitedArea(), Quaternion.identity);
        _uiManager.SetCubeCounter(_freeRoamsList.Count);
    }

    public Vector3 GenerateNewRandomPositionInsideLimitedArea()
    {
        return new Vector3(
            Random.Range(0, AreaLimit.X),
            Random.Range(0, AreaLimit.Y),
            Random.Range(0, AreaLimit.Z)
        );
    }


    public void AddRoamerToTree(FreeRoam roamer)
    {
        if (!_freeRoamingCubes.Contains(roamer))
        {
            _freeRoamingCubes.Add(roamer);
            _freeRoamsList.Add(roamer.gameObject);
        }
    }

    public void RemoveRoamersFromTree(int amountToRemove)
    {
        for (int i = 0; i < amountToRemove; i++)
        {
            _freeRoamingCubes.RemoveAt(0);
            _freeRoamsList.RemoveAt(0);
        }
    }


    private void OnBulkSpawnCubeAction(int value)
    {
        BulkSpawnCubes(value);
    }

    private void OnBulkDespawnCubeAction(int value)
    {
        BulkDespawnCubes(value);
    }

    private void BulkSpawnCubes(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            SpawnCubeAtArbitraryPositionInsideLimitedArea();
        }
    }

    private void BulkDespawnCubes(int amount)
    {
        if (_freeRoamingCubes.Count >= amount)
        {
            for (int i = 0; i < amount; i++)
            {
                _freeRoamsList[i].GetComponent<IPooledObject>().Despawn();
            }

            RemoveRoamersFromTree(amount);

            
        }
        else
        {
            Debug.LogWarning("You are trying to despawn more cubes than you spawned !");
        }

        _uiManager.SetCubeCounter(_freeRoamsList.Count);
    }

    #endregion
}