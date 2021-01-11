using UnityEngine;

namespace MyGame
{
    [CreateAssetMenu(fileName = "MovingObjectsSettings", menuName = "MyAssets/Storages/MovingObjectsSettings")]
    public class MovingObjectsSettings : Storage
    {
        public float MaxSpeed;
    }
}