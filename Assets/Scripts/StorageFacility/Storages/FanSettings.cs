using UnityEngine;

namespace MyGame
{
    [CreateAssetMenu(fileName = "FanSettings", menuName = "MyAssets/Storages/FanSettings")]
    public class FanSettings : Storage
    {
        public Vector3 FanRotation;
        public float RotationSpeed;
        public float RotationSpeedMultiplier;
        public float WindForce; 
        public float WindForceMultiplier;
    }
}