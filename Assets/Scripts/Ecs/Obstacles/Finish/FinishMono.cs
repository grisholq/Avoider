using UnityEngine;

namespace MyGame
{
    public class FinishMono : ObstacleMono
    {
        [SerializeField] private Transform flag;

        private FinishSettings settings;
        private Vector3 flagRotation;

        public override void Inizialize()
        {
            settings = StorageFacility.Instance.GetStorageByType<FinishSettings>();
            flagRotation = settings.FlagRotation * settings.RotationSpeed * settings.RotationSpeedMultiplier;
        }

        public override void Process()
        {
            if (flag != null) flag.Rotate(flagRotation * Time.deltaTime);
        }

        private void OnTriggerEnter(Collider other)
        {
            if(flag != null && other.gameObject.GetComponent<PlayerMono>() != null)
            {
                World.Instance.Current.CreateEntityWith<GameOverEvent>().Type = GameOverType.Victory;
                Destroy(flag.gameObject);
            }
        }
    }
}