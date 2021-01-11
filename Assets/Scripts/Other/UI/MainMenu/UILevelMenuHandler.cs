using UnityEngine;

namespace MyGame
{
    public class UILevelMenuHandler : MonoBehaviour
    {
        public void ChooseLevel(int id)
        {
            GameScenesManager.Instance.UnloadActiveScene();
            GameScenesManager.Instance.LoadLevel(id);
        }

        public void Back()
        {
            UIMenusManager.Instance.ShowMainMenu();
        }
    }
}