using LeopotamGroup.Ecs;

namespace MyGame
{
    [EcsInject]
    public class GameOverSystem : IEcsRunSystem, IEcsInitSystem
    {
        private EcsWorld world = null;

        private EcsFilterSingle<GameOverHanlder> gameOverHandler = null;

        private EcsFilter<GameOverEvent> gameOverEvent = null;

        public void Initialize()
        {
            world.CreateEntityWith<GameOverHanlder>().Inizialize();
        }

        public void Destroy()
        {

        }

        public void Run()
        {
            RunGameOverEvents();
        }

        public void RunGameOverEvents()
        {
            if(gameOverEvent.EntitiesCount > 0)
            {
                if(gameOverEvent.Components1[0].Type == GameOverType.Victory)
                {
                    gameOverHandler.Data.SetVictoryMenuActivity(true);                   
                }

                if (gameOverEvent.Components1[0].Type == GameOverType.Defeat)
                {
                    gameOverHandler.Data.SetRestartMenuActivity(true);                    
                }

                world.CreateEntityWith<NoInputEvent>();
                world.CreateEntityWith<StopTimeEvent>();
                world.CreateEntityWith<PlayerKinematicEvent>();
                World.Instance.RemoveEntitiesWith<GameOverEvent>();
            }
        }
    }
}