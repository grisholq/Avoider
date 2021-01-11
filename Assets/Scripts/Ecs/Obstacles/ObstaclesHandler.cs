using UnityEngine;

namespace MyGame
{
    public class ObstaclesHandler : IInitializable, IProcessable
    {
        private ObstacleMono[] obstacles;
        private Transform obstaclesParent;

        public void Inizialize()
        {
            obstaclesParent = StorageFacility.Instance.GetTransform(TransformObject.ObstaclesParent);

            if (obstaclesParent.childCount == 0)
            {
                obstacles = null;
                return;
            }

            obstacles = obstaclesParent.GetComponentsInChildren<ObstacleMono>();
            foreach (var obstacle in obstacles)
            {
                obstacle.Inizialize();
            }
        }

        public void Process()
        {

            if(obstacles == null || obstacles.Length == 0) return;

            foreach (var obstacle in obstacles)
            {
                obstacle.Process();
            }
        }      
    }
}