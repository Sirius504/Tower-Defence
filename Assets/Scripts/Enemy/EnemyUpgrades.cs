public class EnemyUpgrades
{
    private readonly Enemy.Settings defaultEnemySettings;
    private Enemy.Settings currentEnemySettings;

    public EnemyUpgrades(Enemy.Settings defaultEnemySettings)
    {
        this.defaultEnemySettings = defaultEnemySettings;
        this.currentEnemySettings = new Enemy.Settings();
        currentEnemySettings.lifeSettings = new Life.Settings();
        currentEnemySettings.lifeSettings.maxValue = defaultEnemySettings.lifeSettings.maxValue;
        currentEnemySettings.movementSettings = new TargetMovement.Settings();

    }
}

