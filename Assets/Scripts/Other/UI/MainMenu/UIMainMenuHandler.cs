using UnityEngine;
using UnityEngine.UI;

namespace MyGame
{
    public class UIMainMenuHandler : MonoBehaviour
    {
        [SerializeField] private Image soundImage;
        [SerializeField] private Color soundOnImageColor;
        [SerializeField] private Color soundOffImageColor;

        private void Awake()
        {
            bool state = GameSoundsHandler.Instance.SoundOn;

            if (state)
            {
                soundImage.color = soundOnImageColor;
            }
            else
            {
                soundImage.color = soundOffImageColor;
            }
        }

        public void Play()
        {
            UIMenusManager.Instance.ShowLevelMenu();
        }

        public void Sound()
        {
            bool state = !GameSoundsHandler.Instance.SoundOn;
            GameSoundsHandler.Instance.SoundOn = state;

            if(state)
            {
                soundImage.color = soundOnImageColor;
            }
            else
            {
                soundImage.color = soundOffImageColor;
            }
        }

        public void Quit()
        {
            Application.Quit();
        }
    }
}
