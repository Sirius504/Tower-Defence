using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FiniteStateMachine.States
{
    public abstract class StateBase
    {        
        public virtual List<Transition> Transitions { get; set; }

                
        public StateBase()
        {
            Transitions = new List<Transition>();
        }

        public virtual void OnEnter()
        {

        }

        public virtual void OnExit()
        {

        }

        public virtual IEnumerator ExitTransitionRoutine(Transition transition, Action<Transition> callback)
        {
            callback?.Invoke(transition);
            yield return null;
        }

        public virtual IEnumerator EnterTransitionRoutine()
        {
            OnEnter();
            yield return null;
        }
    }
}
