using UnityEngine;

namespace MyGame
{
    public class CollisionAudioMono : AudioMono
    {
        [SerializeField] private bool IsTrigger;
        [SerializeField] private bool PlayOnce;

        private bool played;

        public override void Inizialize()
        {
            base.Inizialize();
            played = false;
        }

        public override void PlaySound()
        {
            if(PlayOnce)
            {
                if(!played)
                {
                    base.PlaySound();
                    played = true;
                }
            }
            else base.PlaySound();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (!IsTrigger)
            {
                PlaySound();
            }       
        }

        private void OnTriggerEnter(Collider other)
        {
            if (IsTrigger)
            {
                PlaySound();
            }           
        }
    }
}