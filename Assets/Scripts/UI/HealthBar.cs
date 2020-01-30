using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class HealthBar : MonoBehaviour
{
    private Slider slider;
    private ILiving target;

    [Inject]
    public void Contruct(Slider slider, ILiving target)
    {
        this.slider = slider;
        this.target = target;
        target.Life.OnLifeChanged += SetHealthBar;
    }

    private void SetHealthBar(float value)
    {
        slider.normalizedValue = value / target.Life.MaxValue;
    }
}
