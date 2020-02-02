using System;

namespace TowerDefence.Gameplay
{
    public class Counter
    {
        public int Value { get; private set; } = 0;
        public event Action<int> OnChange;

        public virtual void Change(int delta)
        {
            Value += delta;
            OnChange?.Invoke(Value);
        }
    } 
}

