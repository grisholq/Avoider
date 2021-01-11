using UnityEngine;

namespace MyGame
{
    public class InputData
    {
        public Vector2 Start { get; set; }
        public Vector2 Current { get; set; }
        public Vector2 Delta { get; set; }
        public float Magnitude { get; set; }
        public TouchPhase Phase { get; set; }
        public bool IsTap { get; set; }
    }
}