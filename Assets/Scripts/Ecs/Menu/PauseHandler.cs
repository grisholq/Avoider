namespace MyGame
{
    public class PauseHandler : IInitializable
    {
        private UIPauseMenu pauseMenu;

        private MenuSettings settings;

        private bool paused;

        public void Inizialize()
        {
            pauseMenu = StorageFacility.Instance.GetInterface(InterfaceObject.PauseMono).GetComponent<UIPauseMenu>();
            settings = StorageFacility.Instance.GetStorageByType<MenuSettings>();
            paused = false;
            pauseMenu.SetTimeButtonSprite(settings.ResumeButtonSprite);
        }

        public void SwitchTimeButton()
        {            
            if (paused)
            {
                paused = false;
                World.Instance.Current.CreateEntityWith<ResumeTimeEvent>();
                World.Instance.Current.CreateEntityWith<SoundOnEvent>();
                World.Instance.RemoveEntitiesWith<NoInputEvent>(); 
                pauseMenu.SetTimeButtonSprite(settings.ResumeButtonSprite);
            }
            else
            {
                paused = true;
                World.Instance.Current.CreateEntityWith<StopTimeEvent>();
                World.Instance.Current.CreateEntityWith<NoInputEvent>();
                World.Instance.Current.CreateEntityWith<SoundOffEvent>();
                pauseMenu.SetTimeButtonSprite(settings.PauseButtonSprite);
            }
        }
    }
}