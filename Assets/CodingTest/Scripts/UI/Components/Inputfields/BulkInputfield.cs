using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class BulkInputfield : InputfieldComponent
{


    protected override void OnValueChanged(string value)
    {
        _uiManager.SetBulkAmount(this,int.Parse(value)); // didn't use tryparse
                                                         // just because I've set `integer` content type on inputfield
    }

    protected override void OnEndEdit(string value)
    {
        _uiManager.SetBulkAmount(this,int.Parse(value));
    }
    
    private UserInterfaceManager _uiManager;

        
    [Inject]
    private void Construct(UserInterfaceManager uiManager)
    {
        _uiManager = uiManager;
    }
}
