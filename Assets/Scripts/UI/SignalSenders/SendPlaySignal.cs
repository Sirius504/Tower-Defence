using Signals;
using UnityEngine;
using Zenject;

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
        signalBus.Fire(new PlaySignal());
    }
}
