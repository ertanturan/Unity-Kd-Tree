using System;
using UnityEngine;

namespace CodingTest.Scripts.Utility
{
    public class DrawLineBetweenTwoPositions : MonoBehaviour
    {
        private Vector3 _fromVector;
        private Vector3 _toVector;
        
        public void SetVectors(Vector3 from, Vector3 to)
        {
            _fromVector = from;
            _toVector = to;
        }
        
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(_fromVector,_toVector);
        }
    }
}
