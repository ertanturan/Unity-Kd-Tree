using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class DespawnBulkCubeButton : ButtonComponent
{
    
    public override void OnButtonClick()
    {
        _uiManager.OnBulkDespawnButtonClicked();
    }
    
    private UserInterfaceManager _uiManager;

        
    [Inject]
    private void Construct(UserInterfaceManager uiManager)
    {
        _uiManager = uiManager;
    }
    
}
