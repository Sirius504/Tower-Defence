using TMPro;
using UnityEngine;
using Zenject;

public class GoldCounter : MonoBehaviour
{
    private Gold gold;
    private TextMeshProUGUI textMesh;

    [Inject]
    public void Construct(Gold gold, TextMeshProUGUI textMesh)
    {
        this.gold = gold;
        this.textMesh = textMesh;
    }

    private void Start()
    {
        UpdateCounter(gold.Amount);
        gold.OnChanged += UpdateCounter;
    }

    private void UpdateCounter(int gold)
    {
        textMesh.text = $"Gold: {gold}";
    }
}
