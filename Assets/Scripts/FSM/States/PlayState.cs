using System;
using UnityEngine;

namespace FiniteStateMachine.States
{
    public class PlayState : StateBase
    {
        private readonly Canvas inGameInterface;

        public PlayState(Dependencies dependencies)
        {
            this.inGameInterface = dependencies.inGameInterface;
        }

        public override void OnEnter()
        {
            base.OnEnter();
            inGameInterface.gameObject.SetActive(true);
        }

        public override void OnExit()
        {
            base.OnExit();
            inGameInterface.gameObject.SetActive(false);
        }

        [Serializable]
        public class Dependencies
        {
            public Canvas inGameInterface;
        }
    }
}
