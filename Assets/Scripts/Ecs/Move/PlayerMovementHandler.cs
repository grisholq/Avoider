using UnityEngine;

namespace MyGame
{
    public class PlayerMovementHandler : IInitializable
    {
        private Rigidbody player;
        private MoveSettings settings;

        public void Inizialize()
        {
            player = StorageFacility.Instance.GetTransform(TransformObject.Ball).GetComponent<Rigidbody>();
            settings = StorageFacility.Instance.GetStorageByType<MoveSettings>();
        }

        public void ProcessMovement(InputData input)
        {         
            if(input.Phase == TouchPhase.Ended && !input.IsTap)
            {
                Stop();
                Vector2 force = -1 * input.Delta * input.Magnitude * settings.ForceMultiplier;
                force = Vector2.ClampMagnitude(force, settings.MaxForceMagnitude);
                Force(new Vector3(force.x, 0, force.y));
            }
        }

        public void Force(Vector3 force)
        {
            player.AddForce(force);
        }

        public void Reposition(Vector3 position)
        {
            player.transform.position = position;
        }

        public void Stop()
        {
            SetKinematic(true);
            SetKinematic(false);
        }

        public void SetKinematic(bool kinematic)
        {
            player.isKinematic = kinematic;
        }    
    }
}
