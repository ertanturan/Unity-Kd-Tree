using CustomTools.ObjectPooling.Scripts.ObjectPool;

using UnityEngine;
using Zenject;

namespace Test.Scripts.Game
{
    public class FreeRoam : MonoBehaviour,IPooledObject
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

        public PooledObjectType PoolType { get; set; }
        public ObjectPooler Pooler { get; private set; }
    
        [Inject]
        public void Construct(ObjectPooler pooler)
        {
            Pooler = pooler;
        }

        public void OnObjectSpawn()
        {
        }

        public void OnObjectDespawn()
        {
        }

        public void Despawn()
        {
            Pooler.Despawn(gameObject);
        }
    }
}