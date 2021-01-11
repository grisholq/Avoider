using UnityEngine;

namespace MyGame
{
    [CreateAssetMenu(fileName = "TimeSettings", menuName = "MyAssets/Storages/TimeSettings")]
    public class TimeSettings : Storage
    {
        public float TimeScale;
        public float FixedTimeStep;
    }
}