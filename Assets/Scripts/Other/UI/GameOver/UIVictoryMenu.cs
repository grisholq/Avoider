using UnityEngine;
using UnityEngine.UI;

namespace MyGame
{
    public class UIVictoryMenu : MonoBehaviour
    {
        [SerializeField] private Button menuButton;
        [SerializeField] private Button restartButton;
        [SerializeField] private Button nextButton;

        public void SetActivity(bool activity)
        {
            gameObject.SetActive(activity);
        }

        public void SetNextButtonInteractability(bool intr)
        {
            nextButton.interactable = intr;
        }
    }
}