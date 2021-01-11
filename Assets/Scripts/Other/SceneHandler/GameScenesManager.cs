using UnityEngine;
using UnityEngine.SceneManagement;

namespace MyGame
{
    public class GameScenesManager : SingletonBase<GameScenesManager>
    {
        [SerializeField] private int sceneManagerIndex;
        [SerializeField] private int mainMenuIndex;
        [SerializeField] private int firstLevelIndex;
        [SerializeField] private int levelsCount;

        private int activeSceneBuildIndex;
        private int loadingSceneBuildIndex;
        private int unloadingSceneBuildIndex;

        private const int nothing = -1;

        public int ActiveSceneIndex
        {
            get
            {
                return activeSceneBuildIndex == nothing ? loadingSceneBuildIndex : activeSceneBuildIndex;
            }
        }

        private void Start()
        {
            activeSceneBuildIndex = nothing;
            loadingSceneBuildIndex = nothing;
            unloadingSceneBuildIndex = nothing;
            LoadMainMenu();
        }

        public void LoadLevel(int id)
        {
            int index = Mathf.Min(firstLevelIndex + id, firstLevelIndex + levelsCount - 1);
            LoadScene(index);
        }

        public void LoadMainMenu()
        {
            LoadScene(mainMenuIndex);                    
        }

        public void UnloadActiveScene()
        {
            if (activeSceneBuildIndex == nothing) return;
            UnloadScene(activeSceneBuildIndex);
        }

        public void ReloadActiveLevel()
        {
            int curr = activeSceneBuildIndex;
            UnloadScene(activeSceneBuildIndex);
            LoadScene(curr);
        }

        public bool SceneBuildIndexExtists(int index)
        {
            return  index <= (SceneManager.sceneCountInBuildSettings - 1);
        }

        public bool SceneIsLevel(int index)
        {
            return index >= firstLevelIndex && index <= firstLevelIndex + levelsCount - 1;
        }

        public int SceneIndexToLevelIndex(int index)
        {
            return index - firstLevelIndex;
        }

        private void LoadScene(int index)
        {
            loadingSceneBuildIndex = index;
            AsyncOperation loading = SceneManager.LoadSceneAsync(index, LoadSceneMode.Additive);
            loading.completed += new System.Action<AsyncOperation>(OnSceneLoaded);
        }

        private void UnloadScene(int index)
        {
            if(!SceneManager.GetSceneByBuildIndex(index).isLoaded) return;
            unloadingSceneBuildIndex = index;
            AsyncOperation unloading = SceneManager.UnloadSceneAsync(index);
            unloading.completed += OnSceneUnloaded;
        }

        private void SetActiveScene(int index)
        {           
            if (SceneManager.GetSceneByBuildIndex(index).isLoaded)
            {
                SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(index));
                activeSceneBuildIndex = index;
            }          
        }

        private void OnSceneLoaded(AsyncOperation async)
        {
            SetActiveScene(loadingSceneBuildIndex);
            loadingSceneBuildIndex = nothing;
        }

        private void OnSceneUnloaded(AsyncOperation async)
        {
            activeSceneBuildIndex = nothing;
            unloadingSceneBuildIndex = nothing;
        }
    }
}