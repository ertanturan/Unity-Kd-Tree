using System;
using System.Collections;
using System.Collections.Generic;
using CodingTest.Scripts.Game;
using CodingTest.Scripts.Utility;
using UnityEngine;
using Zenject;

public class FindNearestNeighbour : MonoBehaviour
{

    [Inject] private GameManager _gameManager;
    [Inject] private DrawLineBetweenTwoPositions _lineDrawer;
    
    private FreeRoam _nearestNeighbour;

    private void Update()
    {
        FindNearest();
    }

    private void FindNearest()
    {
        _nearestNeighbour = _gameManager.FreeRoamingCubes.FindClosest(transform.position);
        _lineDrawer.SetVectors(transform.position,_nearestNeighbour.transform.position);
    }
    
}
