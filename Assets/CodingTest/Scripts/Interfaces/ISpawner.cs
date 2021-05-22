using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISpawner
{
    PooledObjectType TypeToSpawn { get; set; }
    void SpawnAtDefinition(Vector3 position, Quaternion rotation);
    void Spawn();
}