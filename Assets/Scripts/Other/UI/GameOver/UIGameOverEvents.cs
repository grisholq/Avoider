using UnityEngine;

namespace MyGame
{
    public class UIGameOverEvents : MonoBehaviour
    {
        public void OnMenuButtonPressed()
        {
            World.Instance.Current.CreateEntityWith<ToMainMenuEvent>();
        }

        public void OnRestartButtonPressed()
        {
            World.Instance.Current.CreateEntityWith<RestartLevelEvent>();
        }

        public void OnNextButtonPressed()
        {
            World.Instance.Current.CreateEntityWith<ToNextLevelEvent>();
        }
    }
}