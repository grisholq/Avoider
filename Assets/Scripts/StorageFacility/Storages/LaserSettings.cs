using UnityEngine;

namespace MyGame
{
    [CreateAssetMenu(fileName = "LaserSettings", menuName = "MyAssets/Storages/LaserSettings")]
    public class LaserSettings : Storage
    {
        public float LaserDamage;
        public float LaserDistance;
        public float BackDistance;
    }
}