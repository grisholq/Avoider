using UnityEngine;

namespace MyGame
{
    [CreateAssetMenu(fileName = "CameraSettings", menuName = "MyAssets/Storages/CameraSettings")]
    public class CameraSettings : Storage
    {
        public Vector3 CameraPosition;
        public Vector3 CameraRotation;
    }
}
