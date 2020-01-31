using System;
using UnityEngine;

public class Gold
{
    public int Amount { get; private set; }
    public event Action<int> OnChanged;

    public bool TrySpend(int delta)
    {
        if (Amount - delta < 0)
            return false;
        Amount -= delta;
        OnChanged?.Invoke(Amount);
        return false;
    }

    public void Add(int delta)
    {
        Amount += delta;
        OnChanged?.Invoke(Amount);
    }
}
