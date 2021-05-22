using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UserInterfaceManager : MonoBehaviour
{
    #region Actions

    public Action SpawnCubeButtonClicked;
    public Action<int> BulkSpawnButtonClicked;
    public Action<int> BulkDespawnButtonClicked;

    #endregion

    #region Properties and Fields

    [SerializeField] private InputField _bulkField;

    private int _bulkAmount=0;
    
    #endregion


    #region Custom Methods

    public virtual void OnSpawnButtonClicked()
    {
        SpawnCubeButtonClicked?.Invoke();
    }

    public virtual void OnBulkSpawnButtonClicked()
    {
        BulkSpawnButtonClicked?.Invoke(_bulkAmount);
    }

    public virtual void OnBulkDespawnButtonClicked()
    {
        BulkDespawnButtonClicked?.Invoke(_bulkAmount);
    }

    public int GetBulkAmount()
    {
        return _bulkAmount;
    }

    public void SetBulkAmount(BulkInputfield sender, int value )
    {
        _bulkAmount = value;
    }

    #endregion
}