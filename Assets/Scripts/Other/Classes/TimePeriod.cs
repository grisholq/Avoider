namespace MyGame
{
    public class TimePeriod
    {
        private float lastTime;
        private float period;

        public TimePeriod(float period, float lastTime)
        {
            this.lastTime = lastTime;
            this.period = period;
        }

        public void RestartPeriod(float time)
        {
            lastTime = time;
        }

        public bool PeriodPassed(float time)
        {
            return (time - lastTime) >= period;
        }
    }
}