using System;
using UnityEngine;
using Zenject;

public class CastleRenderer : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    private Health health;
    [SerializeField] private Material damagedMaterial;
    private Material startMaterial;

    private void Start()
    {
        startMaterial = meshRenderer.material;
    }

    [Inject]
    public void Construct(MeshRenderer meshRenderer, Castle castle)
    {
        this.meshRenderer = meshRenderer;
        this.health = castle.Health;
    }

    public void Awake()
    {
        health.OnHealthChanged += ChangeColor;
    }

    private void ChangeColor(float healthValue)
    {
        meshRenderer.material.Lerp(startMaterial, damagedMaterial, 1 - healthValue / health.MaxValue);
    }
}
