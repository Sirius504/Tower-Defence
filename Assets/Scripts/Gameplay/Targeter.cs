using System;
using UnityEngine;

namespace TowerDefence.Gameplay
{
    public abstract class Targeter<T> : MonoBehaviour
    {
        public T CurrentTarget { get; protected set; }
        public event Action<T> OnTargetAcquired;

        protected void InvokeOnTargetAcquired(T target)
        {
            OnTargetAcquired?.Invoke(target);
        }
    } 
}
