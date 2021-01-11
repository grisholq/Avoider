using UnityEngine;
using UnityEngine.UI;

namespace MyGame
{
    public class UIGameOverMenus : MonoBehaviour
    {
        [SerializeField] private UIRestartMenu restartMenu;
        [SerializeField] private UIVictoryMenu victoryMenu;
        
        public UIRestartMenu RestartMenu
        {
            get
            {
                return restartMenu;
            }
        }

        public UIVictoryMenu VictoryMenu
        {
            get
            {
                return victoryMenu;
            }
        }
    }
}