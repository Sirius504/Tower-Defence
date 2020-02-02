using System;
using TowerDefence.Gameplay.HealthSystem;
using UnityEngine;
using Zenject;

namespace TowerDefence.Gameplay.CastleSystem
{
    public class CastleRenderer : MonoBehaviour
    {
        private MeshRenderer meshRenderer;
        private Health health;
        [SerializeField] private Color damagedColor;
        private Color startColor;

        private void Start()
        {
            startColor = meshRenderer.material.color;
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
            meshRenderer.material.color = Color.Lerp(startColor, damagedColor, 1 - healthValue / health.MaxValue);
        }
    } 
}
