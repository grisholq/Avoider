using UnityEngine;
using UnityEngine.UI;

namespace MyGame
{
    public class UIPauseMenu : MonoBehaviour
    {
        [SerializeField] private Image timeImage;

        public void SetTimeButtonSprite(Sprite sprite)
        {
            timeImage.sprite = sprite;
        }
    }
}