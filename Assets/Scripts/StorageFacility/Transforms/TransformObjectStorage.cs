using System;
using UnityEngine;

namespace MyGame
{
    [Serializable]
    public class TransformObjectStorage
    {
        [SerializeField] private TransformObject type;
        [SerializeField] private Transform transform;

        public TransformObject Type
        {
            get
            {
                return type;
            }
        }

        public Transform Transform
        {
            get
            {
                return transform;
            }
        }
    }
}
