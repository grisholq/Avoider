using UnityEngine;

namespace MyGame
{
    [CreateAssetMenu(fileName = "InputSettings", menuName = "MyAssets/Storages/InputSettings")]
    public class InputSettings : Storage
    {
        public float MaxTapMagnitude;
    }
}
