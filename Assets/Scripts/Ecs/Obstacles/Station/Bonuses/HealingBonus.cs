using UnityEngine;

namespace MyGame
{
    [CreateAssetMenu(fileName = "HealingBonus", menuName = "MyAssets/Bonuses/HealingBonus")]
    public class HealingBonus : Bonus
    {
        public override void ApplyBonus()
        {
            World.Instance.Current.CreateEntityWith<HealthRefreshEvent>();
        }
    }
}