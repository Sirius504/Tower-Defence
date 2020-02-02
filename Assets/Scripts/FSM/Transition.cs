using TowerDefence.FiniteStateMachine.States;

namespace TowerDefence.FiniteStateMachine
{
    public class Transition
    {
        public StateBase To { get; }

        public Transition (StateBase to)
        {
            To = to;
        }
    }
}
