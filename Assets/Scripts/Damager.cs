using System;
using Zenject;

public class Damager
{
    public Settings settings;

    [Inject]
    public void Construct(Settings settings)
    {
        this.settings = settings;
    }

    public void DoDamage(ILiving target)
    {
        target.Life.Change(-settings.damage);
    }

    [Serializable]
    public class Settings
    {
        public float damage = 1f;
    }
}

