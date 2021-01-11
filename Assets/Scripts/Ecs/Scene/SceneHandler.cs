using UnityEngine;

namespace MyGame
{
    public class SceneHandler
    {
        public void RestartLevel()
        {
            GameScenesManager.Instance.ReloadActiveLevel();
        }

        public void LoadMainMenu()
        {
            GameScenesManager.Instance.UnloadActiveScene();
            GameScenesManager.Instance.LoadMainMenu();
        }

        public void LoadNextLevel()
        {
            int next = GameScenesManager.Instance.ActiveSceneIndex + 1;
            

            if (GameScenesManager.Instance.SceneBuildIndexExtists(next) && GameScenesManager.Instance.SceneIsLevel(next))
            {
                next = GameScenesManager.Instance.SceneIndexToLevelIndex(next);
                GameScenesManager.Instance.UnloadActiveScene();
                GameScenesManager.Instance.LoadLevel(next);
            }      
        }
    }
}