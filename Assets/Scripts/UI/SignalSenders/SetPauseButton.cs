using Signals;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

[RequireComponent(typeof(Button))]
public class SetPauseButton : MonoBehaviour
{
    [SerializeField] private bool unpause;

    private SignalBus signalBus;
    private Button button;

    [Inject]
    public void Construct(SignalBus signalBus)
    {
        this.signalBus = signalBus;
    }

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonClick);
    }    

    private void OnButtonClick()
    {
        signalBus.Fire(new PauseSignal(!unpause));
    }    
}
