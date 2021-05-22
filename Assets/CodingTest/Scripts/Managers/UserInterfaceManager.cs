using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UserInterfaceManager : MonoBehaviour
{
    public Action SpawnCubeButtonClicked;


    public virtual void OnSpawnButtonClicked()
    {
        SpawnCubeButtonClicked?.Invoke();
    }
}