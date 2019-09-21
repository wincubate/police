namespace Wincubate.Solid.Module01.DomainLayer
{
    // Invariant: When TurnIgnitionKey() has been invoked, IsEngineRunning is true
    public class Car
    {
        public bool IsEngineRunning { get; protected set; }

        public Car()
        {
            IsEngineRunning = false;
        }

        public virtual void TurnIgnitionKey()
        {
            // ...

            IsEngineRunning = true;
        }
    }
}
