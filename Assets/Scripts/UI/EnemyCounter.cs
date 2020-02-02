using TMPro;
using UnityEngine;
using Zenject;

public class EnemyCounter : MonoBehaviour
{
    private TextMeshProUGUI textMesh;
    private KilledEnemyCounter counter;

    [Inject]
    public void Construct(TextMeshProUGUI textMesh, KilledEnemyCounter counter)
    {
        this.textMesh = textMesh;
        this.counter = counter;
    }

    private void Start()
    {
        UpdateCounter(counter.Killed);
        counter.OnChange += UpdateCounter;
    }

    private void UpdateCounter(int value)
    {
        textMesh.text = $"Killed: {value}";
    }
}
