using FiniteStateMachine.States;
using Signals;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace FiniteStateMachine
{
    public class FSMInstaller : MonoInstaller
    {
        [SerializeField] StatesDependencies statesDependencies;
        private FSM fsm;

        public override void InstallBindings()
        {
            SignalBusInstaller.Install(Container);
            fsm = new FSM(CreateStates());
            Container.BindInstance(fsm);
            InstallSignals();
        }

        private void InstallSignals()
        {
            Container.DeclareSignal<PlaySignal>();
            Container.BindSignal<PlaySignal>()
                .ToMethod(s => TransitionOnSignal<PlayState>());
            //Container.DeclareSignal<PauseSignal>();
            //Container.BindSignal<PauseSignal>().ToMethod(OnPauseSignal);
            Container.DeclareSignal<GameOverSignal>();
            Container.BindSignal<GameOverSignal>()
                .ToMethod(s => TransitionOnSignal<GameOverState>());
            Container.DeclareSignal<ExitSignal>();
            Container.BindSignal<ExitSignal>()
                .ToMethod(s =>
                TransitionOnSignal<LoadingState>());
            Container.DeclareSignal<VictorySignal>();
            Container.BindSignal<VictorySignal>()
                .ToMethod(s => TransitionOnSignal<VictoryState>());
        }

        private IEnumerable<StateBase> CreateStates()
        {            
            var playState = new PlayState(statesDependencies.playStateDependencies);
            var gameOverState = new GameOverState(statesDependencies.gameOverStateDependencies);
            var victoryState = new VictoryState(statesDependencies.victoryStateDependencies);
            var loadingState = new LoadingState(0);
            playState.Transitions.Add(new Transition(gameOverState));
            playState.Transitions.Add(new Transition(victoryState));            
            gameOverState.Transitions.Add(new Transition(playState));
            gameOverState.Transitions.Add(new Transition(loadingState));
            victoryState.Transitions.Add(new Transition(playState));
            victoryState.Transitions.Add(new Transition(loadingState));

            return new List<StateBase>()
            {
                playState,
                gameOverState,
                victoryState
            };
        }

        private void TransitionOnSignal<T>() where T: StateBase
        {
            Transition transition = fsm.CurrentState.Transitions.FirstOrDefault(t => t.To is T);
            if (transition == null)
            {
                Debug.LogWarning($"Signal was sent but transition cannot be done.");
                return;
            }
            fsm.ApplyTransition(transition);
        }

        [Serializable]
        public class StatesDependencies
        {
            //public PauseState.Dependencies pauseStateDependencies;
            public PlayState.Dependencies playStateDependencies;
            public GameOverState.Dependencies gameOverStateDependencies;
            public MainMenuState.Dependencies mainMenuStateDependencies;
            public VictoryState.Dependencies victoryStateDependencies;
        }
    }
}
