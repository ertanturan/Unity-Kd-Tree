using UnityEngine;

namespace CodingTest.Scripts.Structs
{
    [System.Serializable]
    public struct LimitedArea 
    {   
        public float X;
        public float Y;
        public float Z;

        private float[] _indexerArray;
    
        public LimitedArea(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        
            _indexerArray =new float[3];

            _indexerArray[0] = x;
            _indexerArray[1] = y;
            _indexerArray[2] = z;
        
        }

        public LimitedArea(Vector3 areaVector)
        {
            X = areaVector.x;
            Y = areaVector.y;
            Z = areaVector.z;
        
            _indexerArray =new float[3];

            _indexerArray[0] = areaVector.x;
            _indexerArray[1] = areaVector.y;
            _indexerArray[2] = areaVector.z;
        }

        public float this[int i]
        {
            get
            {
                return _indexerArray[i];
            }
            set
            {
                _indexerArray[i] = value;
            }
        }

    }
}

