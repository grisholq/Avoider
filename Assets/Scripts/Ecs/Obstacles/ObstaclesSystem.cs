using LeopotamGroup.Ecs;

namespace MyGame
{
    [EcsInject]
    public class ObstaclesSystem : IEcsRunSystem, IEcsInitSystem
    {
        private EcsWorld world = null;

        private EcsFilterSingle<ObstaclesHandler> obstaclesHandlerFilter = null;

        public void Initialize()
        {
            world.CreateEntityWith<ObstaclesHandler>().Inizialize();
        }

        public void Destroy()
        {
            
        }

        public void Run()
        {
            obstaclesHandlerFilter.Data.Process();
        }
    }
}