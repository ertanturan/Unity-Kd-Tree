using CodingTest.Scripts.Structs;
using CustomTools.ObjectPooling.Scripts.ObjectPool;
using UnityEngine;
using Zenject;

namespace CodingTest.Scripts.Game
{
    public class FreeRoam : MonoBehaviour, IPooledObject
    {
        private Vector3 _dynamicTargetPos;

        [Inject] public GameManager GameManager { get; private set; }

        void Update()
        {
            if (IsOnTargetPosition())
            {
                _dynamicTargetPos = GameManager.GenerateNewRandomPositionInsideLimitedArea();
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
   
        public PooledObjectType PoolType { get; set; }
        public ObjectPooler Pooler { get; private set; }

        [Inject]
        public void ConstructPool(ObjectPooler pooler)
        {
            Pooler = pooler;
        }

        public void OnObjectSpawn()
        {
            if (_dynamicTargetPos==Vector3.zero)
            {
                _dynamicTargetPos = transform.position;
            }
            
            GameManager.AddRoamerToTree(this);
            
        }

        public void OnObjectDespawn()
        {
        }

        public void Despawn()
        {
            Debug.Log(Pooler.GetInstanceID());
            Pooler.Despawn(gameObject);
        }
    }
}