using TowerDefence.FiniteStateMachine.States;

namespace TowerDefence.Gameplay
{
    public class KilledEnemiesCounter : Counter
    {
        private readonly FiniteStateMachine.FSM fsm;

        public KilledEnemiesCounter(FiniteStateMachine.FSM fsm)
        {
            this.fsm = fsm;
        }

        public override void Change(int delta)
        {
            if (fsm.CurrentState is PlayState)
                base.Change(delta);
        }
    }
}
