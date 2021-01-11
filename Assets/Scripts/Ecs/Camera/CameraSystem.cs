using LeopotamGroup.Ecs;
using UnityEngine;

namespace MyGame
{
    [EcsInject]
    public class CameraSystem : IEcsRunSystem, IEcsInitSystem
    {
        private EcsWorld world = null;

        private EcsFilterSingle<CameraHandler> cameraHandlerFilter = null;

        public void Initialize()
        {
            world.CreateEntityWith<CameraHandler>().Inizialize();
        }

        public void Destroy()
        {

        }

        public void Run()
        {
            cameraHandlerFilter.Data.ProcessCamera();
        }
    }
}

