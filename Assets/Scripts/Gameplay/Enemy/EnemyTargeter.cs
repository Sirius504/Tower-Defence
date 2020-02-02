using TowerDefence.Gameplay.CastleSystem;
using TowerDefence.Gameplay.HealthSystem;
using TowerDefence.Gameplay.Movement;
using Zenject;

namespace TowerDefence.Gameplay.EnemySystem
{
    public class EnemyTargeter : Targeter<Health>
    {
        private MovementAlongPath pathMovement;
        private Castle castle;

        [Inject]
        public void Construct(MovementAlongPath pathMovement, Castle castle)
        {
            this.pathMovement = pathMovement;
            this.castle = castle;
        }

        public void Start()
        {
            pathMovement.OnPathTraversed += OnCastleReached;
            CurrentTarget = null;
        }

        private void OnCastleReached()
        {
            CurrentTarget = castle.Health;
            InvokeOnTargetAcquired(CurrentTarget);
        }
    }
}
