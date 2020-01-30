using System;
using UnityEngine;
using Zenject;

public class CastleRenderer : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    private Life life;
    [SerializeField] private Material damagedMaterial;
    private Material startMaterial;

    private void Start()
    {
        startMaterial = meshRenderer.material;
    }

    [Inject]
    public void Construct(MeshRenderer meshRenderer, Life life)
    {
        this.meshRenderer = meshRenderer;
        this.life = life;
        life.OnLifeChanged += ChangeColor;
    }

    private void ChangeColor(float lifeValue)
    {
        meshRenderer.material.Lerp(startMaterial, damagedMaterial, 1 - lifeValue / life.MaxValue);
    }
}
