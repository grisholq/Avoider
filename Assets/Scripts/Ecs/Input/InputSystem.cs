using LeopotamGroup.Ecs;
using UnityEngine;

namespace MyGame
{
    [EcsInject]
    public class InputSystem : IEcsRunSystem, IEcsInitSystem
    {
        private EcsWorld world = null;

        private EcsFilterSingle<InputHandler> inputHandlerFilter = null;
        private EcsFilterSingle<InputData> inputDataFilter = null;

        private EcsFilter<NoInputEvent> noInputFilter = null;

        public void Initialize()
        {
            world.CreateEntityWith<InputHandler>().Inizialize();
            world.CreateEntityWith<InputData>();
        }

        public void Destroy()
        {

        }

        public void Run()
        {
            if (noInputFilter.EntitiesCount != 0) return;

            inputHandlerFilter.Data.ProcessInput(inputDataFilter.Data);
        }
    }
}