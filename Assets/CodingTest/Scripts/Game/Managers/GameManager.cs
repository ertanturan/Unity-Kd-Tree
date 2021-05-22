using System.Collections;
using System.Collections.Generic;
using CodingTest.Scripts.Structs;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField]
    public LimitedArea AreaLimit = new LimitedArea(200, 200, 200);
    
}
