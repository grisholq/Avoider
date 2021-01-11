using UnityEngine;

namespace MyGame
{
    [CreateAssetMenu(fileName = "StationSettings", menuName = "MyAssets/Storages/StationSettings")]
    public class StationSettings : Storage
    {
        public Vector3 BonusRotation;
        public float RotationSpeed;
    }
}
