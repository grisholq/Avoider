using UnityEngine;

namespace MyGame
{
    public class SpikesMono : ObstacleMono
    {
        private SpikesSettings settings;

        public override void Inizialize()
        {
            settings = StorageFacility.Instance.GetStorageByType<SpikesSettings>();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if(collision.transform.GetComponent<PlayerMono>() != null)
            {
                World.Instance.Current.CreateEntityWith<HealthDecreaseEvent>().Value = settings.SpikesDamage;
            }
        }
    }
}