using LeopotamGroup.Ecs;

namespace MyGame
{
    [EcsInject]
    public class AimSystem : IEcsRunSystem, IEcsInitSystem
    {
        private EcsWorld world = null;

        private EcsFilterSingle<AimHandler> aimHandlerFilter = null;
        private EcsFilterSingle<InputData> inputDataFilter = null;

        public void Initialize()
        {
            world.CreateEntityWith<AimHandler>().Inizialize();
        }

        public void Destroy()
        {
            
        }

        public void Run()
        {
            aimHandlerFilter.Data.ProcessAiming(inputDataFilter.Data);
        }
    }
}