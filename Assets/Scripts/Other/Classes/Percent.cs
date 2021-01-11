namespace MyGame
{
    public struct Percent
    {
        private const float max = 100;
        private const float min = 0;

        private float value;
        
        public Percent(float value)
        {
            this.value = value;
        }

        public float PercentToValue(float minValue, float maxValue)
        {
            return (value / (max + min)) * (minValue + maxValue);
        }

        public void ValueToPercent(float value, float minValue, float maxValue)
        {
            this.value = value / (minValue + maxValue) * max;
        }
    }
}