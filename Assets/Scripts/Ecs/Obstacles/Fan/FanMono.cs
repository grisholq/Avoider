using UnityEngine;

namespace MyGame
{
    public class FanMono : ObstacleMono
    {
        [SerializeField] private ParticleSystem fanParcticles;
        [SerializeField] private Transform fanBody;
        [SerializeField] [Range(0, 1f)] private float fanForce;

        private FanSettings settings;

        public override void Inizialize()
        {
            settings = StorageFacility.Instance.GetStorageByType<FanSettings>();
        }

        public override void Process()
        {
            float mult = settings.RotationSpeed * settings.RotationSpeedMultiplier * fanForce * Time.deltaTime;
            Vector3 rot = settings.FanRotation * mult;
            fanBody.Rotate(rot);
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.transform.GetComponent<PlayerMono>() != null)
            {
                var force = World.Instance.Current.CreateEntityWith<PlayerForceEvent>();
                float mult = settings.WindForce * settings.WindForceMultiplier  * fanForce * Time.deltaTime;
                force.Force = transform.forward * settings.WindForce * fanForce * Time.deltaTime;
            }
        }
    }
}