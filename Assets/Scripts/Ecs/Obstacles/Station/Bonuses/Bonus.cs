using UnityEngine;

namespace MyGame
{
    public class Bonus : ScriptableObject
    {
        [SerializeField] private Transform bonusPrefab;

        public Transform BonusPrefab
        {
            get
            {
                return bonusPrefab;
            }
        }

        public virtual void ApplyBonus()
        {

        }
    }
}
