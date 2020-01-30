using System;
using UnityEngine;
using Zenject;

namespace FiniteStateMachine.States
{
    public class VictoryState : StateBase
    {
        private readonly Canvas victoryInterface;

        public VictoryState(Dependencies dependencies)
        {
            victoryInterface = dependencies.victoryInterface;
        }

        public override void OnEnter()
        {
            base.OnEnter();
            victoryInterface.gameObject.SetActive(true);
        }

        public override void OnExit()
        {
            base.OnExit();
            victoryInterface.gameObject.SetActive(false);
        }

        [Serializable]
        public class Dependencies
        {
            public Canvas victoryInterface;
        }
    }
}
