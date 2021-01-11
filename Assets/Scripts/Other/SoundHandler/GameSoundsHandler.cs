using UnityEngine;

namespace MyGame
{
    public class GameSoundsHandler : SingletonBase<GameSoundsHandler>
    {
        [SerializeField] private bool soundOn;

        public bool SoundOn
        {
            get
            {
                return soundOn;
            }

            set
            {
                soundOn = value;
            }
        }

        private void Awake()
        {
            SoundOn = true;
        }
    }
}