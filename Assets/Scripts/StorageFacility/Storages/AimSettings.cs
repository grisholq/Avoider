using UnityEngine;

namespace MyGame
{
    [CreateAssetMenu(fileName = "AimSettings", menuName = "MyAssets/Storages/AimSettings")]
    public class AimSettings : Storage
    {      
        public float MaxAimBallsDistance;
        public float AimBallsDeltaMultiplier;
    }
}
