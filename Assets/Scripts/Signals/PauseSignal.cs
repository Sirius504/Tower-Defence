namespace Signals
{
    public class PauseSignal
    {
        public bool Enabled { get; private set; }

        public PauseSignal(bool enable)
        {
            Enabled = enable;
        }
    }
}