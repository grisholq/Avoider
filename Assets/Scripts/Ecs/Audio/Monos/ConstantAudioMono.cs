namespace MyGame
{
    public class ConstantAudioMono : AudioMono
    {
        public override void Inizialize()
        {
            base.Inizialize();
            PlaySound();
        }

        public override void PlaySound()
        {
            if(IsSoundOn)
            {
                sorce.loop = true;
                base.PlaySound();
            }
        }

        public override void StopSound()
        {
            sorce.loop = false;
            base.StopSound();
        }

        public override void SoundOn()
        {
            base.SoundOn();
            PlaySound();
        }

        public override void SoundOff()
        {
            base.SoundOff();
            StopSound();
        }
    }
}