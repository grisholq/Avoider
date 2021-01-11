using UnityEngine;

namespace MyGame
{
    public class HealthHandler : IInitializable
    {
        private float health;

        private HealthSettings settings;

        public bool PlayerIsDead
        {
            get
            {
                return health <= 0;
            }
        }

        public void Inizialize()
        {
            settings = StorageFacility.Instance.GetStorageByType<HealthSettings>();
            health = settings.StartHealth;
        }

        public Percent GetHealthPercent()
        {
            Percent percent = new Percent();
            percent.ValueToPercent(health, settings.MinHealth, settings.MaxHealth);
            return percent;
        }

        public void IncreaseHealth(float value)
        {
            health = Mathf.Min(health + value, settings.MaxHealth);
        }

        public void DecreaseHealth(float value)
        {
            health = Mathf.Max(health - value, settings.MinHealth);
        }

        public void SetFullHealth()
        {
            health = settings.MaxHealth;
        }
    }
}