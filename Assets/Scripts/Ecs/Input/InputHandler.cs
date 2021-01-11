using UnityEngine;

namespace MyGame
{
    public class InputHandler : IInitializable
    {
        private IInputHandler inputHandler;

        private InputSettings settings;

        public void Inizialize()
        {
            if (Application.isEditor)
            {
                inputHandler = new MouseInputHandler();
            }
            else
            {
                inputHandler = new TouchInputHandler();
            }

            settings = StorageFacility.Instance.GetStorageByType<InputSettings>();
        }

        public void ProcessInput(InputData inputData)
        {
            inputHandler.HanldeInput(inputData);

            Vector2 delta = inputData.Current - inputData.Start;

            inputData.Magnitude = delta.magnitude;
            inputData.Delta = delta.normalized;
            inputData.IsTap = inputData.Magnitude <= settings.MaxTapMagnitude;                      
        }
    }
}
