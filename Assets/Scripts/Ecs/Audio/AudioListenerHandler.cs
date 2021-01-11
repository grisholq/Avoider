using UnityEngine;

namespace MyGame
{
    public class AudioListenerHandler : IInitializable, IProcessable
    {
        private Transform ball;
        private Transform listener;

        public void Inizialize()
        {
            ball = StorageFacility.Instance.GetTransform(TransformObject.Ball);
            listener = StorageFacility.Instance.GetTransform(TransformObject.AudioListener);
        }

        public void Process()
        {
            listener.position = ball.position;
        }
    }
}