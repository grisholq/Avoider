using UnityEngine;

namespace MyGame
{
    public class MouseInputHandler : IInputHandler
    {
        public void HanldeInput(InputData inputData)
        {
            bool started = Input.GetMouseButtonDown(0);
            bool moved = Input.GetMouseButton(0);
            bool ended = Input.GetMouseButtonUp(0);

            if (started)
            {
                inputData.Phase = TouchPhase.Began;
                inputData.Start = Input.mousePosition;
                inputData.Current = Input.mousePosition;
                return;
            }
            else if (moved)
            {
                inputData.Phase = TouchPhase.Moved;
                inputData.Current = Input.mousePosition;
                return;
            }
            else if (ended)
            {
                inputData.Phase = TouchPhase.Ended;
                inputData.Current = Input.mousePosition;
                return;
            }
            else
            {
                inputData.Phase = TouchPhase.Canceled;
                inputData.Start = Vector2.zero;
                inputData.Current = Vector2.zero;
            }           
        }     
    }
}