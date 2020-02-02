using TowerDefence.Signals;
using UnityEngine;
using Zenject;

namespace TowerDefence.UI.SignalSenders
{
    public class SendPlaySignal : MonoBehaviour
    {
        private SignalBus signalBus;

        [Inject]
        public void Construct(SignalBus signalBus)
        {
            this.signalBus = signalBus;
        }

        public void SendSignal()
        {
            signalBus.Fire(new RestartSignal());
        }
    }
}
