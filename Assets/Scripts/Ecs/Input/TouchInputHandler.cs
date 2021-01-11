using UnityEngine;

namespace MyGame
{
    public class TouchInputHandler : IInputHandler
    {
        public void HanldeInput(InputData inputData)
        {
            if (Input.touchCount != 1)
            {
                //inputData.Reset();
                return;
            }

            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                inputData.Start = touch.position;
                inputData.Current = touch.position;
            }

            if (touch.phase == TouchPhase.Moved)
            {
                inputData.Current = touch.position;
            }

            if (touch.phase == TouchPhase.Ended)
            {
                inputData.Current = touch.position;
            }

            inputData.Phase = touch.phase;
        }
    }
}