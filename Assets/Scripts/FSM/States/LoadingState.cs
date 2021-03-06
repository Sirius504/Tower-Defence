﻿using UnityEngine;
using UnityEngine.SceneManagement;

namespace TowerDefence.FiniteStateMachine.States
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
            SceneManager.LoadScene(sceneIndex);
        }
    }
}
