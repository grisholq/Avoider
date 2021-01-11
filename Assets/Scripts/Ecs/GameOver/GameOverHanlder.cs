namespace MyGame
{
    public class GameOverHanlder : IInitializable
    {
        private UIGameOverMenus uiGameOver;

        public void Inizialize()
        {
            uiGameOver = StorageFacility.Instance.GetInterface(InterfaceObject.GameOver).GetComponent<UIGameOverMenus>();
        }

        public void SetRestartMenuActivity(bool activity)
        {
            uiGameOver.RestartMenu.SetActivity(activity);
        }

        public void SetVictoryMenuActivity(bool activity)
        {
            uiGameOver.VictoryMenu.SetActivity(activity);

            int index = GameScenesManager.Instance.ActiveSceneIndex + 1;
            bool intr = GameScenesManager.Instance.SceneBuildIndexExtists(index) && GameScenesManager.Instance.SceneIsLevel(index);
            uiGameOver.VictoryMenu.SetNextButtonInteractability(intr);
        }
    }
}