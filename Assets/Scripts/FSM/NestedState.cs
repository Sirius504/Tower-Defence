using System.Collections.Generic;

namespace FiniteStateMachine.States
{
    public class NestedState : StateBase
    {
        private readonly IEnumerable<StateBase> innerStates;
        private readonly int startIndex;
        protected FSM innerFsm;

        public NestedState(IEnumerable<StateBase> innerStates, int startIndex = 0) : base()
        {
            this.innerStates = innerStates;
            this.startIndex = startIndex;
        }

        public override void OnEnter()
        {
            innerFsm = new FSM(innerStates, startIndex);
            base.OnEnter();
            innerFsm.CurrentState.OnEnter();
        }

        public override void OnExit()
        {
            innerFsm.CurrentState.OnExit();
            base.OnExit();
            innerFsm = null;
        }
    }
}
