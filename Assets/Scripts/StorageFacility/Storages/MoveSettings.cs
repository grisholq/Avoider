using UnityEngine;

namespace MyGame
{
    [CreateAssetMenu(fileName = "MoveSettings", menuName = "MyAssets/Storages/MoveSettings")]
    public class MoveSettings : Storage
    {
        public float MaxForceMagnitude;
        public float ForceMultiplier;
    }
}