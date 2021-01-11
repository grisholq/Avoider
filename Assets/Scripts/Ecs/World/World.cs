using UnityEngine;
using LeopotamGroup.Ecs;

namespace MyGame
{
    public class World : SingletonBase<World>
    {
        private EcsSystems systems;
        public EcsWorld Current { get; set; }       

        private void Start()
        {
            Current = new EcsWorld();
            systems = new EcsSystems(Current);

            systems.Add(new InputSystem())
            .Add(new AimSystem())
            .Add(new MoveSystem())
            .Add(new CameraSystem())
            .Add(new TimeSystem())
            .Add(new ObstaclesSystem())
            .Add(new HealthSystem())
            .Add(new AudioSystem())
            .Add(new MenuSystem())
            .Add(new GameOverSystem())
            .Add(new SceneSystem());

            systems.Initialize();
        }

        private void Update()
        {
            systems.Run();
        }

        public void RemoveEntitiesWith<T>() where T : class, new()
        {
            EcsFilter<T> filter = Current.GetFilter<EcsFilter<T>>();
            if (filter.EntitiesCount == 0) return;

            for (int i = 0; i < filter.EntitiesCount; i++)
            {
                Current.RemoveEntity(filter.Entities[i]);
            }            
        }
    }
}