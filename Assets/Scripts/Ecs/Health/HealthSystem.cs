using LeopotamGroup.Ecs;
using UnityEngine;

namespace MyGame
{
    [EcsInject]
    public class HealthSystem : IEcsRunSystem, IEcsInitSystem
    {
        private EcsWorld world = null;

        private EcsFilterSingle<HealthHandler> healthHandlerFilter = null;
        private EcsFilterSingle<HealthBarHandler> healthBarHandlerFilter = null;

        private EcsFilter<HealthRefreshEvent> healthRefreshEvents = null;
        private EcsFilter<HealthIncreaseEvent> healthIncreaseEvents = null;
        private EcsFilter<HealthDecreaseEvent> healthDecreaseEvents = null;

        public void Initialize()
        {
            world.CreateEntityWith<HealthHandler>().Inizialize();
            world.CreateEntityWith<HealthBarHandler>().Inizialize();
        }

        public void Destroy()
        {

        }

        public void Run()
        {           
            ProcessHealthBar(); 
            ProcessHealthEvents();
        }

        public void ProcessHealthBar()
        {
            healthBarHandlerFilter.Data.SetBarWidht(healthHandlerFilter.Data.GetHealthPercent());
           
            if (healthHandlerFilter.Data.PlayerIsDead)
                world.CreateEntityWith<GameOverEvent>().Type = GameOverType.Defeat;
        }

        public void ProcessHealthEvents()
        {
            HealthHandler healthHandler = healthHandlerFilter.Data;

            if (healthRefreshEvents.EntitiesCount > 0)
            {
                healthHandler.SetFullHealth();
                World.Instance.RemoveEntitiesWith<HealthRefreshEvent>();
            }

            if (healthIncreaseEvents.EntitiesCount > 0)
            {
                HealthIncreaseEvent[] healthIncrease = healthIncreaseEvents.Components1;
                for (int i = 0; i < healthIncreaseEvents.EntitiesCount; i++)
                {
                    healthHandler.IncreaseHealth(healthIncrease[i].Value);
                }
                World.Instance.RemoveEntitiesWith<HealthIncreaseEvent>();
            }

            if (healthDecreaseEvents.EntitiesCount > 0)
            {
                HealthDecreaseEvent[] healthDecrease = healthDecreaseEvents.Components1;
                for (int i = 0; i < healthDecreaseEvents.EntitiesCount; i++)
                {
                    healthHandler.DecreaseHealth(healthDecrease[i].Value);
                }              
                World.Instance.RemoveEntitiesWith<HealthDecreaseEvent>();
            }
        }       
    }
}