using TMPro;
using UnityEngine;
using Zenject;

namespace TowerDefence.UI
{
    public class Counter : MonoBehaviour
    {
        private TextMeshProUGUI textMesh;
        private Gameplay.Counter counter;
        private string label;

        [Inject]
        public void Construct(TextMeshProUGUI textMesh, Gameplay.Counter counter, string label)
        {
            this.textMesh = textMesh;
            this.counter = counter;
            this.label = label;
        }

        private void Start()
        {
            UpdateCounter(counter.Value);
            counter.OnChange += UpdateCounter;
        }

        private void UpdateCounter(int value)
        {
            textMesh.text = $"{label}: {value}";
        }
    } 
}
