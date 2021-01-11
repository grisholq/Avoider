using LeopotamGroup.Ecs;
using UnityEngine;

namespace MyGame
{
    [EcsInject]
    public class SceneSystem : IEcsRunSystem, IEcsInitSystem
    {
        private EcsWorld world = null;

        private EcsFilterSingle<SceneHandler> sceneHandlerFilter = null;

        private EcsFilter<RestartLevelEvent> restartLevelEvents = null;
        private EcsFilter<ToMainMenuEvent> mainMenuEvents = null;
        private EcsFilter<ToNextLevelEvent> toNextLevelEvents = null;

        public void Initialize()
        {
            world.CreateEntityWith<SceneHandler>();
        }

        public void Destroy()
        {

        }

        public void Run()
        {
            RunSceneEvents();
        }

        public void RunSceneEvents()
        {
            if(restartLevelEvents.EntitiesCount > 0)
            {
                sceneHandlerFilter.Data.RestartLevel();
                World.Instance.RemoveEntitiesWith<RestartLevelEvent>();
            }

            if (mainMenuEvents.EntitiesCount > 0)
            {
                sceneHandlerFilter.Data.LoadMainMenu();
                World.Instance.RemoveEntitiesWith<ToMainMenuEvent>();
            }

            if (toNextLevelEvents.EntitiesCount > 0)
            {
                sceneHandlerFilter.Data.LoadNextLevel();
                World.Instance.RemoveEntitiesWith<ToNextLevelEvent>();
            }
        }
    }
}