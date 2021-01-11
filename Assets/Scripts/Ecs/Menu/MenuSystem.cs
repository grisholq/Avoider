using LeopotamGroup.Ecs;

namespace MyGame
{
    [EcsInject]
    public class MenuSystem : IEcsRunSystem, IEcsInitSystem
    {
        private EcsWorld world = null;

        private EcsFilterSingle<PauseHandler> pauseHandlerFilter = null;

        private EcsFilter<TimeButtonEvent> timeButtonPressedFilter = null;
        private EcsFilter<RestartButtonEvent> restartButtonPressedFilter = null;
        private EcsFilter<MenuButtonEvent> menuButtonPressedFilter = null;

        public void Initialize()
        {
            world.CreateEntityWith<PauseHandler>().Inizialize();   
        }

        public void Destroy()
        {

        }

        public void Run()
        {
            RunMenuEvents();
        }

        public void RunMenuEvents()
        {
            if (timeButtonPressedFilter.EntitiesCount > 0)
            {
                pauseHandlerFilter.Data.SwitchTimeButton();                
                World.Instance.RemoveEntitiesWith<TimeButtonEvent>();
            }

            if (restartButtonPressedFilter.EntitiesCount > 0)
            {
                world.CreateEntityWith<RestartLevelEvent>();
                World.Instance.RemoveEntitiesWith<RestartButtonEvent>();
            }

            if (menuButtonPressedFilter.EntitiesCount > 0)
            {
                world.CreateEntityWith<ToMainMenuEvent>();
                World.Instance.RemoveEntitiesWith<MenuButtonEvent>();
            }
        }
    }
}