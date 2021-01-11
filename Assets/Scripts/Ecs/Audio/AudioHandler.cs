namespace MyGame
{
    public class AudioHandler : IInitializable
    {
        private AudioMono[] audioMonos;
        private bool soundState;

        public void Inizialize()
        {
            audioMonos = StorageFacility.Instance.GetTransform(TransformObject.AudioParent).GetComponentsInChildren<AudioMono>();

            soundState = GameSoundsHandler.Instance.SoundOn;
            foreach (var audio in audioMonos)
            {
                audio.Inizialize();
                audio.SetSoundState(soundState);        
            }
        }

        public void SoundTurnOn()
        {
            if (soundState == false) return;
            foreach (var audio in audioMonos)
            {
                audio.SoundOn();               
            }
        }

        public void SoundTurnOff()
        {
            foreach (var audio in audioMonos)
            {
                audio.SoundOff();
            }
        }
    }
}