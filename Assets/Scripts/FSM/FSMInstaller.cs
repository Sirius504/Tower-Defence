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

        LoadingState loadMainMenuState;
        LoadingState restartState;

        public override void InstallBindings()
        {
            SignalBusInstaller.Install(Container);
            fsm = new FSM(CreateStates());
            Container.BindInstance(fsm);
            InstallSignals();
        }

        private void InstallSignals()
        {
            Container.DeclareSignal<RestartSignal>();
            Container.BindSignal<RestartSignal>()
                .ToMethod(s => TransitionOnSignal(restartState));
            Container.DeclareSignal<GameOverSignal>();
            Container.BindSignal<GameOverSignal>()
                .ToMethod(s => TransitionOnSignal<GameOverState>());
            Container.DeclareSignal<ExitSignal>();
            Container.BindSignal<ExitSignal>()
                .ToMethod(s =>
                TransitionOnSignal(loadMainMenuState));
        }

        private IEnumerable<StateBase> CreateStates()
        {            
            var playState = new PlayState(statesDependencies.playStateDependencies);
            var gameOverState = new GameOverState(statesDependencies.gameOverStateDependencies);
            loadMainMenuState = new LoadingState(statesDependencies.mainMenuSceneIndex);
            restartState = new LoadingState(statesDependencies.gameSceneIndex);
            playState.Transitions.Add(new Transition(gameOverState));      
            gameOverState.Transitions.Add(new Transition(playState));
            gameOverState.Transitions.Add(new Transition(loadMainMenuState));
            gameOverState.Transitions.Add(new Transition(restartState));

            return new List<StateBase>()
            {
                playState,
                gameOverState
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

        private void TransitionOnSignal(StateBase toState)
        {
            Transition transition = fsm.CurrentState.Transitions.FirstOrDefault(t => t.To.Equals(toState));
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
            public PlayState.Dependencies playStateDependencies;
            public GameOverState.Dependencies gameOverStateDependencies;
            public int mainMenuSceneIndex;
            internal int gameSceneIndex;
        }
    }
}
