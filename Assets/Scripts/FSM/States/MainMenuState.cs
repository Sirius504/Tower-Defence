using System;
using TowerDefence.UI;

namespace TowerDefence.FiniteStateMachine.States
{
    public class MainMenuState : StateBase
    {
        private readonly MainMenuInterface mainMenuInterface;

        public MainMenuState(Dependencies dependencies)
        {
            this.mainMenuInterface = dependencies.mainMenuInterface;
        }

        public override void OnEnter()
        {
            base.OnEnter();
            mainMenuInterface.Open();
        }

        public override void OnExit()
        {
            base.OnExit();
            mainMenuInterface.Close();
        }

        [Serializable]
        public class Dependencies
        {
            public MainMenuInterface mainMenuInterface;
        }
    }
}
