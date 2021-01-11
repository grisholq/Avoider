using System.Collections.Generic;
using UnityEngine;

namespace MyGame
{
    public class MovingObjectMono : ObstacleMono
    {
        [SerializeField] private Transform movingObject;
        [SerializeField] private Transform[] destinations;       
        [SerializeField] [Range(0, 1f)] private float speed;

        private MovingObjectsSettings settings;
        private ObjectsIterator<Transform> destinationsIterator;
        private Transform destination;
        private Vector3 velocity;
        private float distance;

        public override void Inizialize()
        {
            settings = StorageFacility.Instance.GetStorageByType<MovingObjectsSettings>();

            destinationsIterator = new ObjectsIterator<Transform>(destinations);
            
            destination = destinationsIterator.GetCurrent();
            movingObject.position = destination.position;
            ArrivedAtDestination();
        }

        public override void Process()
        {             
            float left = (destination.position - movingObject.position).magnitude;

            if (distance >= left)
            {
                movingObject.position = destination.position;
                ArrivedAtDestination();
            }
            movingObject.Translate(velocity);
        }

        private void ArrivedAtDestination()
        {
            destinationsIterator.MoveToNext();
            if (destinationsIterator.OutOfRange) destinationsIterator.MoveToBegin();

            destination = destinationsIterator.GetCurrent();
            velocity = (destination.position - movingObject.position).normalized * speed * settings.MaxSpeed;
            distance = velocity.magnitude;
        }
    }
}