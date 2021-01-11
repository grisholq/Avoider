using UnityEngine;

namespace MyGame
{
    [CreateAssetMenu(fileName = "MenuSettings", menuName = "MyAssets/Storages/MenuSettings")]
    public class MenuSettings : Storage
    {
        public Sprite PauseButtonSprite;
        public Sprite ResumeButtonSprite;
    }
}