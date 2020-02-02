using System;
using UnityEngine;
using Zenject;

namespace TowerDefence.Gameplay.Movement
{
    public class MovementAlongPath : MonoBehaviour
    {
        private TargetMovement movement;
        private Waypoints waypoints;
        private int currentWaypointIndex = 0;

        public event Action OnPathTraversed;

        [Inject]
        public void Construct(TargetMovement movement, Waypoints waypoints)
        {
            this.movement = movement;
            this.waypoints = waypoints;
        }

        private void Start()
        {
            if (waypoints.WaypointsList.Count > 0)
            {
                movement.OnArrived += OnWaypointArrived;
                movement.TargetTransform = waypoints.WaypointsList[currentWaypointIndex];
            }
        }

        private void OnWaypointArrived()
        {
            if (currentWaypointIndex == waypoints.WaypointsList.Count - 1)
                OnPathTraversed?.Invoke();
            currentWaypointIndex = Mathf.Clamp(++currentWaypointIndex, 0, waypoints.WaypointsList.Count - 1);
            movement.TargetTransform = waypoints.WaypointsList[currentWaypointIndex];
        }

        public Vector3 GetSpeed()
        {
            return movement.GetSpeed();
        }

        private void OnDestroy()
        {
            movement.OnArrived -= OnWaypointArrived;
        }

    } 
}
