using UnityEngine;

namespace MyGame
{
    public class AimHandler : IInitializable
    {
        private Transform ball;
        private Transform aimBallsParent;
        private Transform[] aimBalls;
        private int aimBallsCount;

        private AimSettings settings;

        public void Inizialize()
        {
            ball = StorageFacility.Instance.GetTransform(TransformObject.Ball);
            aimBallsParent = StorageFacility.Instance.GetTransform(TransformObject.AimBallsParent);
            aimBalls = new Transform[aimBallsParent.childCount];
            aimBallsCount = aimBallsParent.childCount;
            settings = StorageFacility.Instance.GetStorageByType<AimSettings>();

            for (int i = 0; i < aimBallsCount; i++)
            {
                aimBalls[i] = aimBallsParent.GetChild(i);
            }

            aimBallsParent.gameObject.SetActive(false);
        }

        public void ProcessAiming(InputData input)
        {
            if (!input.IsTap) 
                ShowAimBalls(input);
            else 
                HideAimBalls();
        }

        private void ShowAimBalls(InputData input)
        {
            Vector3 direction = -1 * new Vector3(input.Delta.x, 0, input.Delta.y);

            float distance = GetAvailableDistance(direction);
          
            int balls = aimBallsCount;
            float delta = input.Magnitude * settings.AimBallsDeltaMultiplier;
            delta = Mathf.Clamp(delta, 0, settings.MaxAimBallsDistance / balls) ;

            balls = (int)Mathf.Floor(distance / delta);

            direction *= delta;

            DrawBalls(ball.position, direction, balls);
        }

        private void HideAimBalls()
        {
            aimBallsParent.gameObject.SetActive(false);
        }

        private void DrawBalls(Vector3 start, Vector3 delta, int amount)
        {
            amount = Mathf.Clamp(amount, 0, aimBallsCount);
            
            aimBallsParent.gameObject.SetActive(true);

            for (int i = 0; i < amount; i++)
            {
                aimBalls[i].position = start + delta * (i + 1);
                aimBalls[i].gameObject.SetActive(true);
            }

            for (int i = amount; i < aimBallsCount; i++)
            {
                aimBalls[i].gameObject.SetActive(false);
            }
        }

        private float GetAvailableDistance(Vector3 direction)
        {
            RaycastHit hit;
            bool hitSomething = Physics.Raycast(ball.position, direction, out hit, settings.MaxAimBallsDistance);

            if (hitSomething)
            {
                return hit.distance;
            }
            else
            {
                return settings.MaxAimBallsDistance;
            }
        }
    }
}
