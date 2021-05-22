using System.Collections;
using System.Collections.Generic;
using CustomTools.ObjectPooling.Scripts.ObjectPool;
using UnityEngine;
using Zenject;

public class CubeSpawner : ISpawner
{

    private ObjectPooler _pooler;

    public CubeSpawner(ObjectPooler pooler , PooledObjectType typeToSpawn)
    {
        TypeToSpawn = typeToSpawn;
        _pooler = pooler;
    }
    
    public PooledObjectType TypeToSpawn { get; set; }
    public void SpawnAtDefinition(Vector3 position, Quaternion rotation)
    {
        _pooler.SpawnFromPool(TypeToSpawn, position, rotation);
        
    }

    public void Spawn()
    {
        _pooler.SpawnFromPool(TypeToSpawn, Vector3.zero, Quaternion.identity);

    }

}
