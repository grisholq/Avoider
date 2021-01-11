using UnityEngine;

namespace MyGame
{
    public class AudioMono : MonoBehaviour
    {
        [SerializeField] protected AudioSource sorce;

        public bool IsSoundOn { get; private set; }

        public bool IsValid
        {
            get
            {
                return sorce != null && sorce.isActiveAndEnabled;
            }
        }

        public virtual void Inizialize()
        {
            IsSoundOn = true;
        }

        public virtual void PlaySound()
        {
            if(IsSoundOn && IsValid) sorce.Play();
        }

        public virtual void StopSound()
        {
            if(IsValid) sorce.Stop();
        }

        public void SetSoundState(bool state)
        {
            if (state) SoundOn();
            else SoundOff();
        }

        public virtual void SoundOn()
        {
            IsSoundOn = true;
        }

        public virtual void SoundOff()
        {
            IsSoundOn = false;
            StopSound();
        }
    }
}