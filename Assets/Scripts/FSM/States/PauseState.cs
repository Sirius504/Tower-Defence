using System;
using System.Collections;
using UnityEngine;

namespace FiniteStateMachine.States
{
    public class PauseState : StateBase
    {
        private const string animationTriggerName = "animate";

        private readonly Canvas pauseInterface;
        private readonly Animator animator;
        private float exitAnimationLength;
        private readonly float defaultTimeScale;

        public PauseState(Dependencies dependencies)
        {
            this.pauseInterface = dependencies.pauseInterface;
            this.animator = dependencies.animator;
            this.exitAnimationLength = dependencies.exitAnimationClip.length;
            this.defaultTimeScale = Time.timeScale;
        }

        public override void OnEnter()
        {
            base.OnEnter();
            pauseInterface.gameObject.SetActive(true);
            Time.timeScale = 0f;
        }

        //public override IEnumerator ExitTransitionRoutine(Transition transition, Action<Transition> callback)
        //{
        //    animator.SetTrigger(animationTriggerName);
        //    yield return new WaitForSecondsRealtime(exitAnimationLength);
        //    pauseInterface.gameObject.SetActive(false);
        //    yield return base.ExitTransitionRoutine(transition, callback);
        //}

        public override void OnExit()
        {
            base.OnExit();
            pauseInterface.gameObject.SetActive(false);
            Time.timeScale = defaultTimeScale;
        }

        [Serializable]
        public class Dependencies
        {
            public Canvas pauseInterface;
            public Animator animator;
            public AnimationClip exitAnimationClip;
        }
    }
}
