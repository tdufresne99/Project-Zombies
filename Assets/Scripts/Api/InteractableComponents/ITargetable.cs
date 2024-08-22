using Api.Inputs.InputUsers;

namespace Api.InteractableComponents
{
    public interface ITargetable : IInputUser
    {
        void OnTargeted();
    }
}