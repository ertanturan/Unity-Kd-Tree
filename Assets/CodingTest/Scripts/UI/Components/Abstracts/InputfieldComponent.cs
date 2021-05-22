using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

[RequireComponent(typeof(InputField))]
public abstract class InputfieldComponent : MonoBehaviour
{
    private InputField _field;

    public virtual void Awake()
    {
        _field = GetComponent<InputField>();

        _field.onEndEdit.AddListener(delegate(string arg) { OnEndEdit(arg); });
        _field.onValueChanged.AddListener(delegate(string arg) { OnValueChanged(arg); });
    }

    protected abstract void OnValueChanged(string value);

    protected abstract void OnEndEdit(string value);
    
}