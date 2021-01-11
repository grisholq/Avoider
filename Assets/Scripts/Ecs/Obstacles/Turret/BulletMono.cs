using UnityEngine;

namespace MyGame
{
    public class BulletMono : MonoBehaviour, IProcessable   
    {
        public float Damage { get; set; }
        public ParticleSystem HitParticles { get; set; }

        private TimePeriod lifePeriod;
       
        public void Shoot(Vector3 velocity, float lifetime)
        {          
            GetComponent<Rigidbody>().AddForce(velocity, ForceMode.VelocityChange);
            lifePeriod = new TimePeriod(lifetime, Time.time);
        }

        public void Process()
        {
            if (lifePeriod.PeriodPassed(Time.time))
            {
                DestoyBullet();
            }
        }
       
        private void DestoyBullet()
        {           
            HitParticles.transform.position = transform.position;
            HitParticles.Play();
            Destroy(gameObject);
            Destroy(this);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.transform.GetComponent<PlayerMono>() != null)
            {
                World.Instance.Current.CreateEntityWith<HealthDecreaseEvent>().Value = Damage;
            }
            DestoyBullet();
        }
    }
}