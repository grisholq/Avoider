using UnityEngine;

namespace MyGame
{
    public class CameraHandler : IInitializable
    {
        private Transform ball;
        private Transform camera;

        private CameraSettings settings;

        public void Inizialize()
        {
            ball = StorageFacility.Instance.GetTransform(TransformObject.Ball);
            camera = StorageFacility.Instance.GetTransform(TransformObject.Camera);
            settings = StorageFacility.Instance.GetStorageByType<CameraSettings>();

            camera.eulerAngles = settings.CameraRotation;
        }

        public void ProcessCamera()
        {
            camera.position = ball.position + settings.CameraPosition;            
        }
    }
}
