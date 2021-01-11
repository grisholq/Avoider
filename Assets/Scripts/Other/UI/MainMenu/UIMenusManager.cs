using UnityEngine;

public class UIMenusManager : SingletonBase<UIMenusManager>
{
    [SerializeField] private RectTransform MainMenu;
    [SerializeField] private RectTransform LevelMenu;

    public void ShowMainMenu()
    {
        MainMenu.gameObject.SetActive(true);
        LevelMenu.gameObject.SetActive(false);
    }

    public void ShowLevelMenu()
    {
        MainMenu.gameObject.SetActive(false);
        LevelMenu.gameObject.SetActive(true);
    }
}