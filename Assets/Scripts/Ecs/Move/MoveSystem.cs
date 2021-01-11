using LeopotamGroup.Ecs;

namespace MyGame
{
    [EcsInject]
    public class MoveSystem : IEcsRunSystem, IEcsInitSystem
    {
        private EcsWorld world = null;

        private EcsFilterSingle<PlayerMovementHandler> moveHandlerFilter = null;
        private EcsFilterSingle<InputData> inputDataFilter = null;

        private EcsFilter<PlayerNoForcesEvent> noForceEvents = null;
        private EcsFilter<PlayerForceEvent> forceEvents = null;
        private EcsFilter<PlayerRepositionEvent> repositionEvents = null;
        private EcsFilter<PlayerKinematicEvent> kinematicEvents = null;

        public void Initialize()
        {
            world.CreateEntityWith<PlayerMovementHandler>().Inizialize();
        }

        public void Destroy()
        {

        }

        public void Run()
        {
            RunMoveEvents();
            RunMovement();
        }

        public void RunMovement()
        {
            moveHandlerFilter.Data.ProcessMovement(inputDataFilter.Data);
        }

        public void RunMoveEvents()
        {
            PlayerMovementHandler moveHandler = moveHandlerFilter.Data;

            if (noForceEvents.EntitiesCount > 0)
            {                
                moveHandler.Stop();   
                World.Instance.RemoveEntitiesWith<PlayerNoForcesEvent>();
            }

            if (forceEvents.EntitiesCount > 0)
            {
                PlayerForceEvent[] events = forceEvents.Components1;
                for (int i = 0; i < forceEvents.EntitiesCount; i++)
                {
                    moveHandler.Force(events[i].Force);
                }
                World.Instance.RemoveEntitiesWith<PlayerForceEvent>();
            }

            if (repositionEvents.EntitiesCount > 0)
            {
                PlayerRepositionEvent moveEvent = repositionEvents.Components1[0];
                moveHandler.Reposition(moveEvent.Position);              
                World.Instance.RemoveEntitiesWith<PlayerRepositionEvent>();
            }

            if (kinematicEvents.EntitiesCount > 0)
            {
                bool kinematic = kinematicEvents.Components1[0].Kinematic;
                moveHandler.SetKinematic(kinematic);
                World.Instance.RemoveEntitiesWith<PlayerKinematicEvent>();
            }
        }
    }
}