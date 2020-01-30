using UnityEngine;
using UnityEngine.SceneManagement;

namespace FiniteStateMachine.States
{
    public class LoadingState : StateBase
    {
        private readonly int sceneIndex;

        public LoadingState(int sceneIndex)
        {
            this.sceneIndex = sceneIndex;
        }

        public override void OnEnter()
        {
            var operation = SceneManager.LoadSceneAsync(sceneIndex);
        }
    }
}
