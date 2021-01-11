using UnityEngine;

namespace MyGame
{
    public class UIPauseEvents : MonoBehaviour
    {
        public void OnTimeButtonPressed()
        {
            World.Instance.Current.CreateEntityWith<TimeButtonEvent>();
        }

        public void OnMainMenuButtonPressed()
        {
            World.Instance.Current.CreateEntityWith<MenuButtonEvent>();
        }

        public void OnRestartButtonPressed()
        {
            World.Instance.Current.CreateEntityWith<RestartButtonEvent>();
        }
    }
}