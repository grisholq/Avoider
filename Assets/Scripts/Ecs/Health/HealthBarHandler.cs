using UnityEngine;

namespace MyGame
{
    public class HealthBarHandler : IInitializable
    {
        private RectTransform healthBar;

        private HealthSettings settings;

        public void Inizialize()
        {
            healthBar = StorageFacility.Instance.GetInterface(InterfaceObject.HealthBar);
            settings = StorageFacility.Instance.GetStorageByType<HealthSettings>();
        }

        public void SetBarWidht(Percent percent)
        {
            float width = percent.PercentToValue(settings.MinBarWidth, settings.MaxBarWidth);
            healthBar.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, width);
        }
    }
}
