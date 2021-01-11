using UnityEngine;

namespace MyGame
{
    [CreateAssetMenu(fileName = "FlameSettings", menuName = "MyAssets/Storages/FlameSettings")]
    public class FlameSettings : Storage
    {
        public float FlameDamage;
    }
}