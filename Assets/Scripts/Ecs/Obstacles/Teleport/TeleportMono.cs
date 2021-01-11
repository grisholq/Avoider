using UnityEngine;

namespace MyGame
{
    public class TeleportMono : ObstacleMono
    {
        [SerializeField] private TeleportMono nextTeleport;
        [SerializeField] private AudioMono audioSorce;

        private TeleportSettings settings;

        public AudioMono OnTeleportingSound
        {
            get
            {
                return audioSorce;
            }
        }

        public override void Inizialize()
        {
            settings = StorageFacility.Instance.GetStorageByType<TeleportSettings>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.transform.GetComponent<PlayerMono>() != null)
            {
                nextTeleport.OnTeleportingSound.PlaySound();

                PlayerForceEvent playerForce = World.Instance.Current.CreateEntityWith<PlayerForceEvent>();
                PlayerRepositionEvent playerMovement = World.Instance.Current.CreateEntityWith<PlayerRepositionEvent>();
                World.Instance.Current.CreateEntityWith<PlayerNoForcesEvent>();

                Vector2 rnd = Random.insideUnitCircle.normalized;
                Vector3 add = new Vector3(rnd.x, 0, rnd.y) ;

                playerMovement.Position = nextTeleport.transform.position;
                playerMovement.Position += add * settings.TeleportAdditionalDistance;
                playerForce.Force = add * settings.TeleportForce;
            }
        }
    }
}