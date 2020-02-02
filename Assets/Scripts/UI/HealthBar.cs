using TowerDefence.Gameplay.HealthSystem;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace TowerDefence.UI
{
    public class HealthBar : MonoBehaviour
    {
        private Slider slider;
        private ILiving target;

        [Inject]
        public void Construct(Slider slider, ILiving target)
        {
            this.slider = slider;
            this.target = target;
        }

        public void Start()
        {
            target.Health.OnHealthChanged += SetHealthBar;
        }

        private void SetHealthBar(float value)
        {
            slider.normalizedValue = value / target.Health.MaxValue;
        }

        private void OnDestroy()
        {
            target.Health.OnHealthChanged -= SetHealthBar;
        }
    } 
}
