using UnityEngine;

namespace MyGame
{
    [CreateAssetMenu(fileName = "HealthSettings", menuName = "MyAssets/Storages/HealthSettings")]
    public class HealthSettings : Storage
    {
        public float MaxHealth;
        public float MinHealth;
        public float StartHealth;

        public float MaxBarWidth;
        public float MinBarWidth;
    }
}
