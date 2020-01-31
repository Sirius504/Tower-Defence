using System;
using UnityEngine;
using Zenject;

public class TargetMovement : MonoBehaviour
{
    [SerializeField] private Transform targetTransform;
    [SerializeField] private Vector3 target;
    public Vector3 Target { get => target; set => target = value; }
    public Transform TargetTransform { get => targetTransform; set => targetTransform = value; }
    private Parameters parameters;

    public event Action OnArrived;
    private bool eventFired = false;

    [Inject]
    public void Construct(Parameters parameters)
    {
        SetParameters(parameters);
    }

    public void SetParameters(Parameters parameters)
    {
        parameters.Validate();
        this.parameters = parameters;
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
        return toTarget.normalized * parameters.Speed;
    }

    private void HandleMovement(Vector3 toTarget)
    {
        transform.position = toTarget.sqrMagnitude < Mathf.Pow(parameters.Speed * Time.deltaTime, 2)
            ? target
            : transform.position + toTarget.normalized * parameters.Speed * Time.deltaTime;
    }

    private void HandleRotation(Vector3 toTarget)
    {
        if (transform.position == target)
            return;
        var newRotation = Quaternion.LookRotation(toTarget);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, Time.deltaTime * parameters.RotationSpeed);
    }

    private void OnDestroy()
    {
        if (OnArrived != null)
            foreach (var d in OnArrived.GetInvocationList())
                OnArrived -= (d as Action);
    }

    [Serializable]
    public class Parameters : ICloneable
    {
        [Min(0.1f)]
        [SerializeField] private float speed;
        public float Speed => speed;
        [Min(0.1f)]
        [SerializeField] private float rotationSpeed;
        public float RotationSpeed => rotationSpeed;

        public Parameters(float speed, float rotationSpeed)
        {
            this.speed = speed;
            this.rotationSpeed = rotationSpeed;
            Validate();
        }

        public object Clone()
        {
            return new Parameters(speed, rotationSpeed);
        }

        public void Validate()
        {
            if (speed <= 0f)
                throw new ArgumentOutOfRangeException("speed", "Speed is less or equals zero");
            if (rotationSpeed <= 0f)
                throw new ArgumentOutOfRangeException("rotationSpeed", "RotationSpeed is less or equals zero");
        }
    }
}
