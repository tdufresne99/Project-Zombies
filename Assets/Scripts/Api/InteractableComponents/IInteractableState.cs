using System;

namespace Api.InteractableComponents
{
    public interface IInteractableState
    {
        InteractableState State { get; }
        event Action<InteractableState> OnInteractableStateChanged;
    }
}