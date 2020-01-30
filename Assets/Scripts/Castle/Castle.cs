using System;
using UnityEngine;
using Zenject;

public class Castle : MonoBehaviour
{
    private Life life;

    [Inject]
    public void Construct(Life life)
    {
        this.life = life;
        life.OnLifeZero += PrintGameOverDebug;
    }

    private void PrintGameOverDebug()
    {
        Debug.Log("GameOver");
    }

    public void TakeDamage(float amount)
    {
        life.Change(-amount);
    }

    [Serializable]
    public class Settings
    {
        public Life.Settings lifeSettings;
    }
}
