using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeRoam : MonoBehaviour
{
    private Vector3 _dynamicTargetPos;

    [SerializeField] private LimitedArea _limitedArea;

    void Update()
    {
        if (IsOnTargetPosition())
        {
            _dynamicTargetPos = GenerateNewRandomPositionInsideLimitedArea();
        }
        else
        {
            MoveToTargetPos();
        }
    }

    private void MoveToTargetPos()
    {
        transform.position = Vector3.Lerp(transform.position, _dynamicTargetPos, 0.01f);
    }

    private bool IsOnTargetPosition()
    {
        return (transform.position - _dynamicTargetPos).magnitude < 0.1;
    }

    private Vector3 GenerateNewRandomPositionInsideLimitedArea()
    {
        return new Vector3(
            Random.Range(0, _limitedArea.X),
            Random.Range(0, _limitedArea.Y),
            Random.Range(0, _limitedArea.Z)
        );
    }
    
}