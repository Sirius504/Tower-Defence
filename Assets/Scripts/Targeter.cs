using System;
using UnityEngine;

public abstract class Targeter<T> : MonoBehaviour
{
    public T CurrentTarget { get; protected set; }
    public event Action<T> OnTargetAcquired;

    protected void InvokeOnTargetAcquired(T target)
    {
        OnTargetAcquired?.Invoke(target);
    }
}
