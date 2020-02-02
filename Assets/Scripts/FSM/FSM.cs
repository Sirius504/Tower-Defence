using System;
using System.Collections.Generic;
using System.Linq;
using TowerDefence.Common;
using TowerDefence.FiniteStateMachine.States;

namespace TowerDefence.FiniteStateMachine
{
    public class FSM
    {
        public StateBase CurrentState { get; private set; }
        public IEnumerable<StateBase> States { get; }

        public FSM(IEnumerable<StateBase> states, int startStateIndex = 0)
        {
            States = states;
            CurrentState = States.ElementAt(startStateIndex);
            CurrentState.OnEnter();
        }

        public void ApplyTransition(Transition transition)
        {
            if (transition == null)
                throw new ArgumentNullException("transition");

            if (CurrentState == null)
                throw new InvalidOperationException();

            if (!CurrentState.Transitions.Contains(transition))
                throw new InvalidOperationException($"Transition \"{transition}\" not found in CurrentState: \"{CurrentState}\"");

            CoroutineSingleton.StartCoroutine(CurrentState.ExitTransitionRoutine(transition, OnStateExit));
        }

        private void OnStateExit(Transition transition)
        {
            CurrentState.OnExit();
            CurrentState = transition.To;
            CoroutineSingleton.StartCoroutine(CurrentState.EnterTransitionRoutine());
        }
    }
}
