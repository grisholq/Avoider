using UnityEngine;

namespace MyGame
{
    [CreateAssetMenu(fileName = "TeleportSettings", menuName = "MyAssets/Storages/TeleportSettings")]
    public class TeleportSettings : Storage
    {
        public float TeleportAdditionalDistance;
        public float TeleportForce;
    }
}