using UnityEngine;

namespace MyGame
{
    [CreateAssetMenu(fileName = "FinishSettings", menuName = "MyAssets/Storages/FinishSettings")]
    public class FinishSettings : Storage
    {
        public Vector3 FlagRotation;
        public float RotationSpeed; 
        public float RotationSpeedMultiplier;
    }
}
