using System;
using UnityEngine;
using Zenject;

public class TargetMovement : MonoBehaviour
{
    [SerializeField] private Transform targetTransform;
    [SerializeField] private Vector3 target;
    public Vector3 Target { get => target; set => target = value; }
    public Transform TargetTransform { get => targetTransform; set => targetTransform = value; }
    private Settings settings;

    public event Action OnArrived;
    private bool eventFired = false;

    [Inject]
    public void Construct(Settings settings)
    {
        this.settings = settings;
    }

    // Update is called once per frame
    private void Update()
    {
        if (targetTransform != null)
            Target = targetTransform.position;
        var toTarget = target - transform.position;
        HandleRotation(toTarget);
        HandleMovement(toTarget);
        HandleArrivalEvent();
    }

    private void HandleArrivalEvent()
    {
        if (transform.position == target && !eventFired)        
            OnArrived?.Invoke();        
        eventFired = transform.position == target;
    }

    public Vector3 GetSpeed()
    {
        var toTarget = target - transform.position;
        return toTarget.normalized * settings.speed;
    }

    private void HandleMovement(Vector3 toTarget)
    {
        transform.position = toTarget.sqrMagnitude < Mathf.Pow(settings.speed * Time.deltaTime, 2)
            ? target
            : transform.position + toTarget.normalized * settings.speed * Time.deltaTime;
    }

    private void HandleRotation(Vector3 toTarget)
    {
        if (transform.position == target)
            return;
        var newRotation = Quaternion.LookRotation(toTarget);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, Time.deltaTime * settings.rotationSpeed);
    }

    private void OnDestroy()
    {
        if (OnArrived != null)
            foreach (var d in OnArrived.GetInvocationList())
                OnArrived -= (d as Action);
    }

    [Serializable]
    public class Settings
    {
        public float speed;
        public float rotationSpeed;
    }
}
