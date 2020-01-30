using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    [SerializeField] private List<Transform> waypoints;
    [SerializeField] private float debugSphereRadius = .4f;
    public List<Transform> WaypointsList { get => waypoints; }

    private void OnDrawGizmos()
    {
        if (waypoints.Count == 0)
            return;
        Vector3 previousPoint = waypoints[0].position;
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(waypoints[0].position, debugSphereRadius);
        foreach (var point in waypoints.Skip(1).Select(w => w.position))
        {
            Gizmos.color = Color.magenta;
            Gizmos.DrawSphere(point, debugSphereRadius);
            Gizmos.color = Color.red;
            Gizmos.DrawLine(point, previousPoint);
            previousPoint = point;
        }
    }
}
