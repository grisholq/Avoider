using UnityEngine;
using UnityEngine.UI;

namespace MyGame
{
    public class UIRestartMenu : MonoBehaviour
    {
        [SerializeField] private Button restartButton; 
        
        public void SetActivity(bool activity)
        {
            this.gameObject.SetActive(activity);
        }
    }
}