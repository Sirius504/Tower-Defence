using System;
using UnityEngine;

namespace FiniteStateMachine.States
{
    public class GameOverState : StateBase
    {
        private Canvas gameOverInterface;

        public GameOverState(Dependencies dependencies)
        {
            this.gameOverInterface = dependencies.gameOverInterface;
        }

        public override void OnEnter()
        {
            base.OnEnter();
            gameOverInterface.gameObject.SetActive(true);
        }

        public override void OnExit()
        {
            base.OnExit();
            gameOverInterface.gameObject.SetActive(false);
        }

        [Serializable]
        public class Dependencies
        {
            public Canvas gameOverInterface;
        }
    }
}