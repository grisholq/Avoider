using LeopotamGroup.Ecs;

namespace MyGame
{
    [EcsInject]
    public class AudioSystem : IEcsRunSystem, IEcsInitSystem
    {
        private EcsWorld world = null;

        private EcsFilterSingle<AudioHandler> audioHandlerFilter = null;
        private EcsFilterSingle<AudioListenerHandler> listenerHandlerFilter = null;

        private EcsFilter<SoundOnEvent> soundOnEvents = null;
        private EcsFilter<SoundOffEvent> soundOffEvents = null;

        public void Initialize()
        {
            world.CreateEntityWith<AudioHandler>().Inizialize();
            world.CreateEntityWith<AudioListenerHandler>().Inizialize();
        }

        public void Destroy()
        {

        }

        public void Run()
        {
            listenerHandlerFilter.Data.Process();
            RunEvents();
        }

        private void RunEvents()
        {
            if(soundOnEvents.EntitiesCount > 0)
            {
                audioHandlerFilter.Data.SoundTurnOn();
                World.Instance.RemoveEntitiesWith<SoundOnEvent>();
            }

            if (soundOffEvents.EntitiesCount > 0)
            {
                audioHandlerFilter.Data.SoundTurnOff(); 
                World.Instance.RemoveEntitiesWith<SoundOffEvent>();
            }
        }
    }
}