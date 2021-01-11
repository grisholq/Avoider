using UnityEngine;

namespace MyGame
{
    [CreateAssetMenu(fileName = "SawsSettings", menuName = "MyAssets/Storages/SawsSettings")]
    public class SawsSettings : Storage
    {
        public float SawsDamage;
        public Vector3 SawsRotation;
        public float RotationCoefficient;
    }
}
