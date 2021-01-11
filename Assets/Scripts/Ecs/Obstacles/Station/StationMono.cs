using UnityEngine;

namespace MyGame
{
    public class StationMono : ObstacleMono
    {
        [SerializeField] private Bonus bonus;
        [SerializeField] private Transform bonusPosition;

        private StationSettings settings;
        private Transform bonusInstance;
        private Vector3 bonusRotation;

        public override void Inizialize()
        {
            bonusInstance = Instantiate(bonus.BonusPrefab);
            bonusInstance.position = bonusPosition.position;
            bonusInstance.parent = transform;

            settings = StorageFacility.Instance.GetStorageByType<StationSettings>();
            bonusRotation = settings.BonusRotation * settings.RotationSpeed;
        }

        public override void Process()
        {
            if (bonusInstance != null) bonusInstance.Rotate(bonusRotation * Time.deltaTime);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (bonusInstance != null && other.transform.GetComponent<PlayerMono>() != null)
            {
                Destroy(bonusInstance.gameObject);
                bonusInstance = null;
                World.Instance.Current.CreateEntityWith<HealthRefreshEvent>();
            }
        }
    }
}