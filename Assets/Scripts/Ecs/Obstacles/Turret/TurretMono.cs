using UnityEngine;
using System.Collections.Generic;

namespace MyGame
{
    public class TurretMono : ObstacleMono
    {
        [SerializeField] private Transform turretBody;

        [SerializeField] private ParticleSystem shotParticles;
        [SerializeField] private ParticleSystem hitParticles;

        [SerializeField] private AudioMono shotSound;

        [SerializeField] private Transform bulletPosition;
        [SerializeField] private Transform bulletParent;

        [SerializeField] private float period;

        private TurretSettings settings;
        private List<BulletMono> bullets;
        private TimePeriod reloadPeriod;
        private Transform bulletPrefab;

        public override void Inizialize()
        {
            settings = StorageFacility.Instance.GetStorageByType<TurretSettings>();
            bulletPrefab = StorageFacility.Instance.GetPrefab(PrefabObject.Bullet);

            reloadPeriod = new TimePeriod(period, Time.time);
            bullets = new List<BulletMono>();
        }

        public override void Process()
        {
            UpdateBullets();

            float time = Time.time;
            if (reloadPeriod.PeriodPassed(time))
            {
                Shot();
                reloadPeriod.RestartPeriod(time);                
            }                    
        }

        private void Shot()
        {
            BulletMono bullet = Instantiate(bulletPrefab).gameObject.AddComponent<BulletMono>();

            bullet.transform.position = bulletPosition.position;
            bullet.transform.SetParent(bulletParent);

            bullet.Damage = settings.BulletDamage;
            bullet.HitParticles = hitParticles;
            bullet.Shoot(transform.forward * settings.BulletSpeed, settings.BulletLifetime);
            bullets.Add(bullet);

            shotParticles.Play();
            shotSound.PlaySound();
        }

        private void UpdateBullets()
        {
            bullets.RemoveAll(i => i == null);

            foreach (var bullet in bullets)
            {
                bullet.Process();
            }          
        }
    }
}