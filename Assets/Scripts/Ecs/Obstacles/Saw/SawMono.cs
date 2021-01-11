using UnityEngine;

namespace MyGame
{
    public class SawMono : ObstacleMono
    {
        [SerializeField] private Transform sawEdge;
        [SerializeField] private ParticleSystem sawUpParticles;
        [SerializeField] private ParticleSystem sawDownParticles;      
        [SerializeField] private AudioMono hitSound;

        private SawsSettings settings;
        private Vector3 sawRotation;

        public override void Inizialize()
        {
            settings = StorageFacility.Instance.GetStorageByType<SawsSettings>();
            sawRotation = settings.SawsRotation * settings.RotationCoefficient;
        }

        public override void Process()
        {
            sawEdge.Rotate(sawRotation * Time.deltaTime);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.transform.GetComponent<PlayerMono>() != null)
            {
                hitSound.PlaySound();

                World.Instance.Current.CreateEntityWith<HealthDecreaseEvent>().Value = settings.SawsDamage;

                ContactPoint contact = collision.contacts[0];
                sawUpParticles.transform.position = contact.point;
                sawDownParticles.transform.position = contact.point;

                sawUpParticles.Play();
                sawDownParticles.Play();
            }
        }
    }
}