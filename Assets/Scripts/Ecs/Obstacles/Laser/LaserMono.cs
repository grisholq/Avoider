using UnityEngine;

namespace MyGame
{
    public class LaserMono : ObstacleMono
    {
        [SerializeField] ParticleSystem laserParticles;
        [SerializeField] LineRenderer laserRenderer;
        [SerializeField] Transform laserBody;

        private LaserSettings settings;

        public override void Inizialize()
        {
            settings = StorageFacility.Instance.GetStorageByType<LaserSettings>();
        }

        public override void Process()
        {
            float distance = settings.LaserDistance;
            float back = settings.BackDistance;
            RaycastHit hit;

            bool hitSome = Physics.Raycast(laserBody.position, laserBody.forward, out hit, distance);
            if (hitSome)
            {
                if (hit.transform.GetComponent<PlayerMono>())
                {
                    HealthDecreaseEvent healthDecrease = World.Instance.Current.CreateEntityWith<HealthDecreaseEvent>();
                    healthDecrease.Value = settings.LaserDamage * Time.deltaTime;
                }
                DrawLaserLine((hit.point - laserBody.position).magnitude);
                laserParticles.transform.position = hit.point - laserBody.forward * back;
                return;
            }
            laserParticles.transform.position = laserBody.position + laserBody.forward * distance;
            DrawLaserLine(distance);
        }

        private void DrawLaserLine(float distance)
        {
            laserRenderer.SetPosition(0, laserBody.position);
            laserRenderer.SetPosition(1, laserBody.position + laserBody.forward * distance);
        }
    }
}
