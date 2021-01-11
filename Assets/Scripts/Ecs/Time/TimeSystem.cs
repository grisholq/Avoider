using LeopotamGroup.Ecs;

namespace MyGame
{
    [EcsInject]
    public class TimeSystem : IEcsRunSystem, IEcsInitSystem
    {
        private EcsWorld world = null;

        private EcsFilterSingle<TimeHandler> timeHandlerFilter = null;
        
        private EcsFilter<ResumeTimeEvent> resumeTimeEvents = null;
        private EcsFilter<StopTimeEvent> stopTimeEvents = null;

        public void Initialize()
        {
            world.CreateEntityWith<TimeHandler>().Inizialize();
        }

        public void Destroy()
        {

        }

        public void Run()
        {
            RunTimeEvents();
        }

        public void RunTimeEvents()
        {
            if (resumeTimeEvents.EntitiesCount > 0)
            {
                timeHandlerFilter.Data.ResumeTime();
                World.Instance.RemoveEntitiesWith<ResumeTimeEvent>();
            }

            if (stopTimeEvents.EntitiesCount > 0)
            {
                timeHandlerFilter.Data.StopTime();
                World.Instance.RemoveEntitiesWith<StopTimeEvent>();
            }        
        }
    }
}