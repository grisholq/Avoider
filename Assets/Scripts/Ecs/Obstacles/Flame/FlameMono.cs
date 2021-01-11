using UnityEngine;

namespace MyGame
{
    public class FlameMono : ObstacleMono
    {
        [SerializeField] private ParticleSystem flameParticles;
        [SerializeField] private Transform flameBody;

        private FlameSettings settings;

        public override void Inizialize()
        {
            settings = StorageFacility.Instance.GetStorageByType<FlameSettings>();
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.transform.GetComponent<PlayerMono>() != null)
            {
                World.Instance.Current.CreateEntityWith<HealthDecreaseEvent>().Value = settings.FlameDamage * Time.deltaTime;
            }
        }
    }
}
