using FiniteStateMachine.States;

namespace FiniteStateMachine
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
