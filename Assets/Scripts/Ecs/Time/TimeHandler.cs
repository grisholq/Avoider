using UnityEngine;

namespace MyGame
{
    public class TimeHandler : IInitializable
    {
        private TimeSettings settings;
        
        public void Inizialize()
        {
            settings = StorageFacility.Instance.GetStorageByType<TimeSettings>();
            ResumeTime();
        }

        public void ResumeTime()
        {
            Time.timeScale = settings.TimeScale;
            Time.fixedDeltaTime = settings.FixedTimeStep;
        }

        public void StopTime()
        {
            Time.timeScale = 0;
            Time.fixedDeltaTime = 0;
        }      
    }
}
