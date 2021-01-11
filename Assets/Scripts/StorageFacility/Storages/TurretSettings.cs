using UnityEngine;

namespace MyGame
{
    [CreateAssetMenu(fileName = "TurretSettings", menuName = "MyAssets/Storages/TurretSettings")]
    public class TurretSettings : Storage
    {
        public float BulletSpeed;
        public float BulletDamage;
        public float BulletLifetime;
    }
}

